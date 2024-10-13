//using System;
//using System.Collections.Generic;

//namespace CachingProxyPattern
//{
//    // Subject: Kullanıcı verisi arayüzü
//    public interface IUserService
//    {
//        string GetUserDetails(int userId);
//    }

//    // RealSubject: Gerçek kullanıcı verisi sağlayan sınıf (örneğin bir veritabanı)
//    public class UserService : IUserService
//    {
//        public string GetUserDetails(int userId)
//        {
//            // Veritabanına sorgu simülasyonu
//            Console.WriteLine($"Fetching details for user {userId} from the database...");
//            return $"User{userId} Details: Name - John Doe, Age - 30";
//        }
//    }

//    // Proxy: Kullanıcı verilerini önbellekte tutan önbellek proxy sınıfı
//    public class UserServiceProxy : IUserService
//    {
//        private UserService _realUserService;
//        private Dictionary<int, string> _cache;

//        public UserServiceProxy()
//        {
//            _realUserService = new UserService();
//            _cache = new Dictionary<int, string>();
//        }

//        public string GetUserDetails(int userId)
//        {
//            if (_cache.ContainsKey(userId))
//            {
//                Console.WriteLine($"Returning cached data for user {userId}");
//                return _cache[userId];
//            }
//            else
//            {
//                // Veri önbellekte yoksa veritabanından getiriliyor
//                string userDetails = _realUserService.GetUserDetails(userId);
//                _cache[userId] = userDetails; // Sonuç önbelleğe kaydediliyor
//                return userDetails;
//            }
//        }
//    }

//    // Client code
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Proxy ile kullanıcı servisi oluşturuluyor
//            IUserService userService = new UserServiceProxy();

//            // İlk istekte veritabanından veri çekiliyor
//            Console.WriteLine(userService.GetUserDetails(1));
//            Console.WriteLine();

//            // İkinci istekte aynı veri önbellekten getiriliyor
//            Console.WriteLine(userService.GetUserDetails(1));
//            Console.WriteLine();

//            // Farklı bir kullanıcı için veri çekiliyor (veritabanından)
//            Console.WriteLine(userService.GetUserDetails(2));
//            Console.WriteLine();

//            // Aynı kullanıcı için önbelleğe alınmış veri getiriliyor
//            Console.WriteLine(userService.GetUserDetails(2));
//        }
//    }
//}
