//using System;

//public class Database
//{
//    // The field for storing the singleton instance should be declared static.
//    private static Database instance;

//    // An object used for thread synchronization (lock).
//    private static readonly object lockObj = new object();

//    // The singleton's constructor should always be private to prevent direct construction.
//    private Database()
//    {
//        // Some initialization code, such as connecting to a database server.
//        Console.WriteLine("Initializing the database connection...");
//    }

//    // The static method that controls access to the singleton instance.
//    public static Database GetInstance()
//    {
//        if (instance == null)
//        {
//            lock (lockObj) // Ensure thread safety.
//            {
//                // Double-check locking to prevent multiple threads from creating separate instances.
//                if (instance == null)
//                {
//                    instance = new Database();
//                }
//            }
//        }

//        return instance;
//    }

//    // Business logic, such as executing a query.
//    public void Query(string sql)
//    {
//        // In a real-world scenario, execute the SQL query against the database.
//        Console.WriteLine($"Executing query: {sql}");
//    }
//}

//public class Application
//{
//    public static void Main(string[] args)
//    {
//        // Get the singleton instance and execute some queries.
//        Database foo = Database.GetInstance();
//        foo.Query("SELECT * FROM users");

//        // Get the singleton instance again (this will return the same instance).
//        Database bar = Database.GetInstance();
//        bar.Query("SELECT * FROM products");

//        // Both `foo` and `bar` reference the same Database instance.
//        Console.WriteLine($"foo and bar are the same instance: {ReferenceEquals(foo, bar)}");
//    }
//}
