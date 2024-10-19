//using System;

//namespace BridgePatternComplex
//{
//    // Abstraction (Payment)
//    public abstract class Payment
//    {
//        protected IPaymentProcessor processor;

//        public Payment(IPaymentProcessor processor)
//        {
//            this.processor = processor;
//        }

//        public abstract void MakePayment();
//    }

//    // Refined Abstraction (Card Payment)
//    public class CardPayment : Payment
//    {
//        private string cardNumber;
//        private double amount;

//        public CardPayment(IPaymentProcessor processor, string cardNumber, double amount) : base(processor)
//        {
//            this.cardNumber = cardNumber;
//            this.amount = amount;
//        }

//        public override void MakePayment()
//        {
//            Console.WriteLine($"Processing card payment of {amount} using card {cardNumber}");
//            processor.ProcessPayment(amount);
//        }
//    }

//    // Refined Abstraction (Bank Transfer Payment)
//    public class BankTransferPayment : Payment
//    {
//        private string accountNumber;
//        private double amount;

//        public BankTransferPayment(IPaymentProcessor processor, string accountNumber, double amount) : base(processor)
//        {
//            this.accountNumber = accountNumber;
//            this.amount = amount;
//        }

//        public override void MakePayment()
//        {
//            Console.WriteLine($"Processing bank transfer of {amount} from account {accountNumber}");
//            processor.ProcessPayment(amount);
//        }
//    }

//    // Refined Abstraction (Digital Wallet Payment)
//    public class WalletPayment : Payment
//    {
//        private string walletId;
//        private double amount;

//        public WalletPayment(IPaymentProcessor processor, string walletId, double amount) : base(processor)
//        {
//            this.walletId = walletId;
//            this.amount = amount;
//        }

//        public override void MakePayment()
//        {
//            Console.WriteLine($"Processing wallet payment of {amount} from wallet ID {walletId}");
//            processor.ProcessPayment(amount);
//        }
//    }

//    // Implementation (Payment Processor)
//    public interface IPaymentProcessor
//    {
//        void ProcessPayment(double amount);
//    }

//    // Concrete Implementation for PayPal Processor
//    public class PayPalProcessor : IPaymentProcessor
//    {
//        public void ProcessPayment(double amount)
//        {
//            Console.WriteLine($"PayPal processing payment of {amount}");
//            // Simulate PayPal payment logic
//        }
//    }

//    // Concrete Implementation for Stripe Processor
//    public class StripeProcessor : IPaymentProcessor
//    {
//        public void ProcessPayment(double amount)
//        {
//            Console.WriteLine($"Stripe processing payment of {amount}");
//            // Simulate Stripe payment logic
//        }
//    }

//    // Concrete Implementation for Square Processor
//    public class SquareProcessor : IPaymentProcessor
//    {
//        public void ProcessPayment(double amount)
//        {
//            Console.WriteLine($"Square processing payment of {amount}");
//            // Simulate Square payment logic
//        }
//    }

//    // Client Code
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            // PayPal with card payment
//            IPaymentProcessor paypalProcessor = new PayPalProcessor();
//            Payment cardPayment = new CardPayment(paypalProcessor, "1234-5678-9012-3456", 250.00);
//            cardPayment.MakePayment();

//            // Stripe with bank transfer payment
//            IPaymentProcessor stripeProcessor = new StripeProcessor();
//            Payment bankPayment = new BankTransferPayment(stripeProcessor, "ACC12345678", 1000.00);
//            bankPayment.MakePayment();

//            // Square with wallet payment
//            IPaymentProcessor squareProcessor = new SquareProcessor();
//            Payment walletPayment = new WalletPayment(squareProcessor, "WALLET001", 150.00);
//            walletPayment.MakePayment();
//        }
//    }
//}
