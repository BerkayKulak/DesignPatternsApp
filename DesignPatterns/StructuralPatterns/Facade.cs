//using System;

//namespace FacadePattern
//{
//    // Müşteri doğrulama sistemi
//    public class AuthenticationService
//    {
//        public bool Authenticate(string customerId, string password)
//        {
//            // Simulated authentication process
//            Console.WriteLine($"Authenticating customer {customerId}...");
//            return customerId == "12345" && password == "password";
//        }
//    }

//    // Banka hesap bakiyesi kontrol sistemi
//    public class AccountService
//    {
//        public double GetBalance(string accountId)
//        {
//            // Simulated balance retrieval
//            Console.WriteLine($"Fetching balance for account {accountId}...");
//            return 1000.00;
//        }

//        public void DeductAmount(string accountId, double amount)
//        {
//            // Simulated balance deduction
//            Console.WriteLine($"Deducting {amount:C2} from account {accountId}");
//        }

//        public void AddAmount(string accountId, double amount)
//        {
//            // Simulated balance addition
//            Console.WriteLine($"Adding {amount:C2} to account {accountId}");
//        }
//    }

//    // Para transferi sistemi
//    public class TransferService
//    {
//        public void TransferFunds(string fromAccount, string toAccount, double amount)
//        {
//            Console.WriteLine($"Transferring {amount:C2} from {fromAccount} to {toAccount}");
//        }
//    }

//    // Kredi kartı ödeme sistemi
//    public class CreditCardService
//    {
//        public void PayCreditCardBill(string cardNumber, double amount)
//        {
//            Console.WriteLine($"Paying {amount:C2} towards credit card {cardNumber}");
//        }
//    }

//    // Fatura ödeme sistemi
//    public class BillPaymentService
//    {
//        public void PayBill(string biller, double amount)
//        {
//            Console.WriteLine($"Paying {amount:C2} to {biller}");
//        }
//    }

//    // Facade: Banka işlemleri yöneten basit bir arayüz
//    public class BankFacade
//    {
//        private AuthenticationService _authService;
//        private AccountService _accountService;
//        private TransferService _transferService;
//        private CreditCardService _creditCardService;
//        private BillPaymentService _billPaymentService;

//        public BankFacade()
//        {
//            _authService = new AuthenticationService();
//            _accountService = new AccountService();
//            _transferService = new TransferService();
//            _creditCardService = new CreditCardService();
//            _billPaymentService = new BillPaymentService();
//        }

//        public bool Login(string customerId, string password)
//        {
//            return _authService.Authenticate(customerId, password);
//        }

//        public void Transfer(string customerId, string password, string fromAccount, string toAccount, double amount)
//        {
//            if (Login(customerId, password))
//            {
//                double balance = _accountService.GetBalance(fromAccount);
//                if (balance >= amount)
//                {
//                    _transferService.TransferFunds(fromAccount, toAccount, amount);
//                    _accountService.DeductAmount(fromAccount, amount);
//                    _accountService.AddAmount(toAccount, amount);
//                }
//                else
//                {
//                    Console.WriteLine("Insufficient balance for transfer.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Authentication failed.");
//            }
//        }

//        public void PayCreditCard(string customerId, string password, string cardNumber, double amount)
//        {
//            if (Login(customerId, password))
//            {
//                double balance = _accountService.GetBalance(customerId);
//                if (balance >= amount)
//                {
//                    _creditCardService.PayCreditCardBill(cardNumber, amount);
//                    _accountService.DeductAmount(customerId, amount);
//                }
//                else
//                {
//                    Console.WriteLine("Insufficient balance to pay credit card.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Authentication failed.");
//            }
//        }

//        public void PayBill(string customerId, string password, string biller, double amount)
//        {
//            if (Login(customerId, password))
//            {
//                double balance = _accountService.GetBalance(customerId);
//                if (balance >= amount)
//                {
//                    _billPaymentService.PayBill(biller, amount);
//                    _accountService.DeductAmount(customerId, amount);
//                }
//                else
//                {
//                    Console.WriteLine("Insufficient balance to pay bill.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Authentication failed.");
//            }
//        }
//    }

//    // Client code
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            BankFacade bankFacade = new BankFacade();

//            // Kullanıcı giriş yapıyor ve para transferi yapıyor
//            Console.WriteLine("\n--- Transfering funds ---");
//            bankFacade.Transfer("12345", "password", "12345", "67890", 200.00);

//            // Kredi kartı borcu ödeniyor
//            Console.WriteLine("\n--- Paying credit card bill ---");
//            bankFacade.PayCreditCard("12345", "password", "9876-5432-1234-5678", 500.00);

//            // Fatura ödeniyor
//            Console.WriteLine("\n--- Paying bill ---");
//            bankFacade.PayBill("12345", "password", "Electricity", 150.00);
//        }
//    }
//}
