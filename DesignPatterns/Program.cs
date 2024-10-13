using System;

namespace DecoratorPattern
{
    // The component interface defines operations that can be altered by decorators.
    public interface IDataSource
    {
        void WriteData(string data);
        string ReadData();
    }

    // Concrete components provide default implementations for the operations.
    public class FileDataSource : IDataSource
    {
        private string _filename;

        public FileDataSource(string filename)
        {
            _filename = filename;
        }

        public void WriteData(string data)
        {
            Console.WriteLine($"Writing data to file: {_filename}");
            // Simulate writing to a file
        }

        public string ReadData()
        {
            Console.WriteLine($"Reading data from file: {_filename}");
            // Simulate reading from a file
            return "file data";
        }
    }

    // The base decorator class follows the same interface as the other components.
    public class DataSourceDecorator : IDataSource
    {
        protected IDataSource _wrappee;

        public DataSourceDecorator(IDataSource source)
        {
            _wrappee = source;
        }

        public virtual void WriteData(string data)
        {
            _wrappee.WriteData(data);
        }

        public virtual string ReadData()
        {
            return _wrappee.ReadData();
        }
    }

    // Concrete decorators must call methods on the wrapped object but may add behavior.
    public class EncryptionDecorator : DataSourceDecorator
    {
        public EncryptionDecorator(IDataSource source) : base(source) { }

        public override void WriteData(string data)
        {
            string encryptedData = Encrypt(data);
            Console.WriteLine("Data has been encrypted.");
            base.WriteData(encryptedData);
        }

        public override string ReadData()
        {
            string data = base.ReadData();
            string decryptedData = Decrypt(data);
            Console.WriteLine("Data has been decrypted.");
            return decryptedData;
        }

        private string Encrypt(string data)
        {
            // Simulate encryption logic
            return $"encrypted({data})";
        }

        private string Decrypt(string data)
        {
            // Simulate decryption logic
            return data.Replace("encrypted(", "").Replace(")", "");
        }
    }

    public class CompressionDecorator : DataSourceDecorator
    {
        public CompressionDecorator(IDataSource source) : base(source) { }

        public override void WriteData(string data)
        {
            string compressedData = Compress(data);
            Console.WriteLine("Data has been compressed.");
            base.WriteData(compressedData);
        }

        public override string ReadData()
        {
            string data = base.ReadData();
            string decompressedData = Decompress(data);
            Console.WriteLine("Data has been decompressed.");
            return decompressedData;
        }

        private string Compress(string data)
        {
            // Simulate compression logic
            return $"compressed({data})";
        }

        private string Decompress(string data)
        {
            // Simulate decompression logic
            return data.Replace("compressed(", "").Replace(")", "");
        }
    }

    // Example client code that uses external data source.
    public class SalaryManager
    {
        private IDataSource _source;

        public SalaryManager(IDataSource source)
        {
            _source = source;
        }

        public void Save(string salaryRecords)
        {
            _source.WriteData(salaryRecords);
        }

        public string Load()
        {
            return _source.ReadData();
        }
    }

    // Application configurator for assembling decorators.
    public class ApplicationConfigurator
    {
        public void ConfigurationExample(bool enableEncryption, bool enableCompression)
        {
            IDataSource source = new FileDataSource("salary.dat");

            if (enableEncryption)
            {
                source = new EncryptionDecorator(source);
            }

            if (enableCompression)
            {
                source = new CompressionDecorator(source);
            }

            SalaryManager manager = new SalaryManager(source);
            manager.Save("salary data");

            string salary = manager.Load();
            Console.WriteLine($"Loaded salary data: {salary}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ApplicationConfigurator configurator = new ApplicationConfigurator();

            // Example 1: Compression and encryption both enabled
            Console.WriteLine("Configuration 1: Compression and Encryption Enabled");
            configurator.ConfigurationExample(enableEncryption: true, enableCompression: true);

            // Example 2: Only encryption enabled
            Console.WriteLine("\nConfiguration 2: Only Encryption Enabled");
            configurator.ConfigurationExample(enableEncryption: true, enableCompression: false);

            // Example 3: No decorators
            Console.WriteLine("\nConfiguration 3: No Decorators");
            configurator.ConfigurationExample(enableEncryption: false, enableCompression: false);
        }
    }
}
