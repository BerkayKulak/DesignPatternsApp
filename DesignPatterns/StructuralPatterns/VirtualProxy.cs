//using System;

//namespace VirtualProxyPattern
//{
//    // Subject: Ortak resim arayüzü
//    public interface IImage
//    {
//        void Display();
//    }

//    // RealSubject: Gerçek resim dosyası sınıfı
//    public class RealImage : IImage
//    {
//        private string _filename;

//        public RealImage(string filename)
//        {
//            _filename = filename;
//            LoadImageFromDisk();
//        }

//        private void LoadImageFromDisk()
//        {
//            Console.WriteLine($"Loading image from disk: {_filename}");
//            // Simulated long operation (image loading)
//        }

//        public void Display()
//        {
//            Console.WriteLine($"Displaying {_filename}");
//        }
//    }

//    // Proxy: Resim dosyasını yalnızca gerektiğinde yükleyen sanal proxy
//    public class ImageProxy : IImage
//    {
//        private RealImage _realImage;
//        private string _filename;

//        public ImageProxy(string filename)
//        {
//            _filename = filename;
//        }

//        public void Display()
//        {
//            if (_realImage == null)
//            {
//                // Nesne ilk kez kullanıldığında gerçek nesne yaratılıyor
//                Console.WriteLine("Image not loaded yet, loading on demand...");
//                _realImage = new RealImage(_filename);
//            }

//            // Resim yüklenmişse, doğrudan gösteriliyor
//            _realImage.Display();
//        }
//    }

//    // Client code
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Resim dosyası, Proxy üzerinden temsil ediliyor
//            IImage image1 = new ImageProxy("high_resolution_image1.jpg");
//            IImage image2 = new ImageProxy("high_resolution_image2.jpg");

//            // İlk görüntüleme isteği
//            Console.WriteLine("\nFirst request for image1:");
//            image1.Display(); // Resim yüklenecek ve gösterilecek

//            // İkinci görüntüleme isteği
//            Console.WriteLine("\nSecond request for image1:");
//            image1.Display(); // Resim önceden yüklendiği için doğrudan gösterilecek

//            // Farklı bir resim için ilk görüntüleme isteği
//            Console.WriteLine("\nFirst request for image2:");
//            image2.Display(); // Bu resim henüz yüklenmemiş, şimdi yüklenecek ve gösterilecek
//        }
//    }
//}
