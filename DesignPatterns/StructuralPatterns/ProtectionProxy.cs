//using System;

//namespace ProxyPattern
//{
//    // Subject: Banka hesap arayüzü
//    public interface IBankAccount
//    {
//        void Deposit(double amount);
//        void Withdraw(double amount);
//        double GetBalance();
//    }

//    // RealSubject: Gerçek banka hesabı sınıfı
//    public class BankAccount : IBankAccount
//    {
//        private double balance;

//        public BankAccount(double initialBalance)
//        {
//            balance = initialBalance;
//        }

//        public void Deposit(double amount)
//        {
//            balance += amount;
//            Console.WriteLine($"Deposited: {amount:C2}, New Balance: {balance:C2}");
//        }

//        public void Withdraw(double amount)
//        {
//            if (balance >= amount)
//            {
//                balance -= amount;
//                Console.WriteLine($"Withdrew: {amount:C2}, New Balance: {balance:C2}");
//            }
//            else
//            {
//                Console.WriteLine("Insufficient funds for this withdrawal.");
//            }
//        }

//        public double GetBalance()
//        {
//            return balance;
//        }
//    }

//    // Proxy: Banka hesabına erişimi kontrol eden koruyucu proxy sınıfı
//    public class BankAccountProxy : IBankAccount
//    {
//        private BankAccount _realAccount;
//        private string _password;

//        public BankAccountProxy(string password, double initialBalance)
//        {
//            _realAccount = new BankAccount(initialBalance);
//            _password = password;
//        }

//        private bool Authenticate(string inputPassword)
//        {
//            if (inputPassword == _password)
//            {
//                Console.WriteLine("Authentication successful.");
//                return true;
//            }
//            else
//            {
//                Console.WriteLine("Authentication failed. Access denied.");
//                return false;
//            }
//        }

//        public void Deposit(double amount)
//        {
//            Console.WriteLine("Authentication required for deposit.");
//            Console.Write("Enter password: ");
//            string inputPassword = Console.ReadLine();

//            if (Authenticate(inputPassword))
//            {
//                _realAccount.Deposit(amount);
//            }
//        }

//        public void Withdraw(double amount)
//        {
//            Console.WriteLine("Authentication required for withdrawal.");
//            Console.Write("Enter password: ");
//            string inputPassword = Console.ReadLine();

//            if (Authenticate(inputPassword))
//            {
//                _realAccount.Withdraw(amount);
//            }
//        }

//        public double GetBalance()
//        {
//            Console.WriteLine("Authentication required for balance inquiry.");
//            Console.Write("Enter password: ");
//            string inputPassword = Console.ReadLine();

//            if (Authenticate(inputPassword))
//            {
//                return _realAccount.GetBalance();
//            }
//            else
//            {
//                return 0.0;
//            }
//        }
//    }

//    // Client Code
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Proxy kullanarak banka hesabı oluşturma
//            BankAccountProxy account = new BankAccountProxy("securepassword", 500.00);

//            // Para yatırma işlemi
//            account.Deposit(100.00);

//            // Para çekme işlemi
//            account.Withdraw(50.00);

//            // Hesap bakiyesi sorgulama
//            double balance = account.GetBalance();
//            Console.WriteLine($"Balance: {balance:C2}");
//        }
//    }
//}
