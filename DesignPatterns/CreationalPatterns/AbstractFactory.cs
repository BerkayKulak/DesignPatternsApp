//using System;

//// The abstract factory interface declares a set of methods that
//// return different abstract products. These products are called
//// a family and are related by a high-level theme or concept.
//public interface IGUIFactory
//{
//    IButton CreateButton();
//    ICheckbox CreateCheckbox();
//}

//// Concrete factories produce a family of products that belong
//// to a single variant. The factory guarantees that the
//// resulting products are compatible. Signatures of the concrete
//// factory's methods return an abstract product, while inside
//// the method a concrete product is instantiated.
//public class WinFactory : IGUIFactory
//{
//    public IButton CreateButton()
//    {
//        return new WinButton();
//    }

//    public ICheckbox CreateCheckbox()
//    {
//        return new WinCheckbox();
//    }
//}

//// Each concrete factory has a corresponding product variant.
//public class MacFactory : IGUIFactory
//{
//    public IButton CreateButton()
//    {
//        return new MacButton();
//    }

//    public ICheckbox CreateCheckbox()
//    {
//        return new MacCheckbox();
//    }
//}

//// Each distinct product of a product family should have a base
//// interface. All variants of the product must implement this
//// interface.
//public interface IButton
//{
//    void Paint();
//}

//// Concrete products are created by corresponding concrete
//// factories.
//public class WinButton : IButton
//{
//    public void Paint()
//    {
//        // Render a button in Windows style.
//        Console.WriteLine("Rendering a button in Windows style.");
//    }
//}

//public class MacButton : IButton
//{
//    public void Paint()
//    {
//        // Render a button in macOS style.
//        Console.WriteLine("Rendering a button in macOS style.");
//    }
//}

//// Here's the base interface of another product. All products
//// can interact with each other, but proper interaction is
//// possible only between products of the same concrete variant.
//public interface ICheckbox
//{
//    void Paint();
//}

//public class WinCheckbox : ICheckbox
//{
//    public void Paint()
//    {
//        // Render a checkbox in Windows style.
//        Console.WriteLine("Rendering a checkbox in Windows style.");
//    }
//}

//public class MacCheckbox : ICheckbox
//{
//    public void Paint()
//    {
//        // Render a checkbox in macOS style.
//        Console.WriteLine("Rendering a checkbox in macOS style.");
//    }
//}

//// The client code works with factories and products only
//// through abstract types: IGUIFactory, IButton, and ICheckbox. This
//// lets you pass any factory or product subclass to the client
//// code without breaking it.
//public class Application
//{
//    private IGUIFactory _factory;
//    private IButton _button;

//    public Application(IGUIFactory factory)
//    {
//        _factory = factory;
//    }

//    public void CreateUI()
//    {
//        _button = _factory.CreateButton();
//    }

//    public void Paint()
//    {
//        _button.Paint();
//    }
//}

//// The application picks the factory type depending on the
//// current configuration or environment settings and creates it
//// at runtime (usually at the initialization stage).
//public class ApplicationConfigurator
//{
//    public static void Main(string[] args)
//    {
//        // Simulate reading configuration
//        string configOS = ReadApplicationConfigFile();

//        IGUIFactory factory;

//        if (configOS == "Windows")
//        {
//            factory = new WinFactory();
//        }
//        else if (configOS == "Mac")
//        {
//            factory = new MacFactory();
//        }
//        else
//        {
//            throw new Exception("Error! Unknown operating system.");
//        }

//        Application app = new Application(factory);
//        app.CreateUI();
//        app.Paint();
//    }

//    private static string ReadApplicationConfigFile()
//    {
//        // For demonstration purposes, return either "Windows" or "Mac"
//        return "Windows"; // Change to "Mac" to simulate macOS version
//    }
//}
