using System;
using System.Collections.Generic;

namespace CompositePatternComplex
{
    // Component: Ortak arayüz hem bireysel ürünler hem de paketler için kullanılır.
    public abstract class OrderComponent
    {
        public abstract string GetName();
        public abstract double GetPrice();
        public virtual void Add(OrderComponent component)
        {
            throw new NotImplementedException("This operation is not supported.");
        }

        public virtual void Remove(OrderComponent component)
        {
            throw new NotImplementedException("This operation is not supported.");
        }

        public virtual List<OrderComponent> GetItems()
        {
            throw new NotImplementedException("This operation is not supported.");
        }
    }

    // Leaf: Bireysel Ürün (Tek başına satılan bir ürün)
    public class Product : OrderComponent
    {
        private string name;
        private double price;

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public override string GetName()
        {
            return name;
        }

        public override double GetPrice()
        {
            return price;
        }
    }

    // Composite: Paket (Birden fazla üründen oluşan kombinasyon)
    public class ProductBundle : OrderComponent
    {
        private List<OrderComponent> items = new List<OrderComponent>();
        private string bundleName;

        public ProductBundle(string name)
        {
            this.bundleName = name;
        }

        public override string GetName()
        {
            return bundleName;
        }

        public override double GetPrice()
        {
            double total = 0;
            foreach (var item in items)
            {
                total += item.GetPrice();
            }
            return total;
        }

        public override void Add(OrderComponent component)
        {
            items.Add(component);
        }

        public override void Remove(OrderComponent component)
        {
            items.Remove(component);
        }

        public override List<OrderComponent> GetItems()
        {
            return items;
        }
    }

    // Client: Sipariş yönetim sistemi
    public class OrderSystem
    {
        private OrderComponent order;

        public OrderSystem(OrderComponent order)
        {
            this.order = order;
        }

        public void PrintOrderDetails()
        {
            Console.WriteLine($"Order Summary for: {order.GetName()}");
            Console.WriteLine($"Total Price: {order.GetPrice():C2}");

            if (order is ProductBundle)
            {
                PrintBundleItems(order);
            }
        }

        private void PrintBundleItems(OrderComponent component)
        {
            var items = component.GetItems();
            foreach (var item in items)
            {
                Console.WriteLine($" - {item.GetName()} : {item.GetPrice():C2}");
                if (item is ProductBundle)
                {
                    PrintBundleItems(item); // Nested bundles
                }
            }
        }
    }

    // Main Program
    public class Program
    {
        public static void Main(string[] args)
        {
            // Tekil Ürünler
            OrderComponent laptop = new Product("Laptop", 1200.00);
            OrderComponent phone = new Product("Smartphone", 800.00);
            OrderComponent mouse = new Product("Wireless Mouse", 40.00);

            // Paket: Ofis Paketi
            ProductBundle officeBundle = new ProductBundle("Office Package");
            officeBundle.Add(laptop);
            officeBundle.Add(mouse);

            // Paket: Teknoloji Paketi (İçinde başka bir paket var)
            ProductBundle techBundle = new ProductBundle("Tech Bundle");
            techBundle.Add(officeBundle);
            techBundle.Add(phone);

            // Sipariş sistemi: Teknoloji paketini ve tekil ürünleri içeren bir sipariş oluştur
            OrderComponent fullOrder = new ProductBundle("Full Order");
            fullOrder.Add(techBundle);

            // Sipariş detaylarını yazdır
            OrderSystem orderSystem = new OrderSystem(fullOrder);
            orderSystem.PrintOrderDetails();
        }
    }
}
