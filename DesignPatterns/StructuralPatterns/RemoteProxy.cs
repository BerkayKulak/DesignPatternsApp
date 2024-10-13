//using System;

//namespace RemoteProxyPattern
//{
//    // Subject: Ortak veritabanı arayüzü
//    public interface IDatabase
//    {
//        void Connect();
//        string GetData(int userId);
//        void Disconnect();
//    }

//    // RealSubject: Gerçek veritabanı sınıfı (uzakta bulunan)
//    public class RemoteDatabase : IDatabase
//    {
//        private string serverAddress;

//        public RemoteDatabase(string serverAddress)
//        {
//            this.serverAddress = serverAddress;
//        }

//        public void Connect()
//        {
//            Console.WriteLine($"Connecting to remote database at {serverAddress}...");
//        }

//        public string GetData(int userId)
//        {
//            Console.WriteLine($"Fetching data for user {userId} from remote database...");
//            // Simulated data fetching
//            return $"UserData for User {userId}";
//        }

//        public void Disconnect()
//        {
//            Console.WriteLine("Disconnecting from remote database.");
//        }
//    }

//    // Proxy: Uzak sunucudaki veritabanına erişimi kontrol eden proxy sınıfı
//    public class DatabaseProxy : IDatabase
//    {
//        private RemoteDatabase _realDatabase;
//        private string _serverAddress;
//        private bool _isConnected = false;

//        public DatabaseProxy(string serverAddress)
//        {
//            _serverAddress = serverAddress;
//        }

//        public void Connect()
//        {
//            if (!_isConnected)
//            {
//                _realDatabase = new RemoteDatabase(_serverAddress);
//                _realDatabase.Connect();
//                _isConnected = true;
//            }
//            else
//            {
//                Console.WriteLine("Already connected to the database.");
//            }
//        }

//        public string GetData(int userId)
//        {
//            if (!_isConnected)
//            {
//                Console.WriteLine("You must connect to the database first.");
//                return null;
//            }

//            return _realDatabase.GetData(userId);
//        }

//        public void Disconnect()
//        {
//            if (_isConnected)
//            {
//                _realDatabase.Disconnect();
//                _isConnected = false;
//            }
//            else
//            {
//                Console.WriteLine("No active database connection to disconnect.");
//            }
//        }
//    }

//    // Client code
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Proxy kullanarak uzak veritabanına bağlanma
//            IDatabase database = new DatabaseProxy("192.168.1.100");

//            // Bağlantı sağlanıyor
//            database.Connect();

//            // Veritabanından veri çekiliyor
//            string data = database.GetData(123);
//            Console.WriteLine($"Data received: {data}");

//            // Bağlantı sonlandırılıyor
//            database.Disconnect();
//        }
//    }
//}
