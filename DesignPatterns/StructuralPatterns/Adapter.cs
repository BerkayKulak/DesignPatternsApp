//using System;
//using Newtonsoft.Json;
//using System.Xml;
//using System.Xml.Linq;

//// Target interface: Sistem JSON formatını bekliyor.
//public interface IJsonParser
//{
//    string GetJsonData();
//}

//// Adaptee: XML formatında veri döndüren sınıf.
//public class XmlParser
//{
//    public string GetXmlData()
//    {
//        // Basit bir XML örneği
//        return @"<Employee><Name>John Doe</Name><Position>Software Developer</Position><Department>IT</Department></Employee>";
//    }
//}

//// Adapter: XML verilerini JSON formatına dönüştürüp sisteme sunuyor.
//public class JsonToXmlAdapter : IJsonParser
//{
//    private XmlParser _xmlParser;

//    public JsonToXmlAdapter(XmlParser xmlParser)
//    {
//        _xmlParser = xmlParser;
//    }

//    // XML verisini alıp JSON formatına çeviriyor.
//    public string GetJsonData()
//    {
//        string xmlData = _xmlParser.GetXmlData();
//        XmlDocument doc = new XmlDocument();
//        doc.LoadXml(xmlData);

//        // XML'i JSON'a çevir
//        string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);
//        return jsonText;
//    }
//}

//// Client: JSON formatında veri bekleyen sistem.
//public class Client
//{
//    private IJsonParser _jsonParser;

//    public Client(IJsonParser jsonParser)
//    {
//        _jsonParser = jsonParser;
//    }

//    public void DisplayData()
//    {
//        string jsonData = _jsonParser.GetJsonData();
//        Console.WriteLine("Data in JSON format:");
//        Console.WriteLine(jsonData);
//    }
//}

//// Program: JSON formatı isteyen sistemi çalıştırıyoruz.
//public class Program
//{
//    public static void Main(string[] args)
//    {
//        // XML formatında veri döndüren bir sistem var
//        XmlParser xmlParser = new XmlParser();

//        // Adapter kullanarak XML verisini JSON formatına uyarlıyoruz
//        IJsonParser adapter = new JsonToXmlAdapter(xmlParser);

//        // Client JSON formatında veri alıyor
//        Client client = new Client(adapter);
//        client.DisplayData();
//    }
//}
