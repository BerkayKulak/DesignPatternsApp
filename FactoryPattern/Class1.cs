using System;

// The creator class declares the factory method that must
// return an object of a product class. The creator's subclasses
// usually provide the implementation of this method.
abstract class Dialog
{
    // The creator may also provide some default implementation
    // of the factory method.
    public abstract IButton CreateButton();

    // Note that, despite its name, the creator's primary
    // responsibility isn't creating products. It usually
    // contains some core business logic that relies on product
    // objects returned by the factory method. Subclasses can
    // indirectly change that business logic by overriding the
    // factory method and returning a different type of product
    // from it.
    public void Render()
    {
        // Call the factory method to create a product object.
        IButton okButton = CreateButton();
        // Now use the product.
        okButton.OnClick(CloseDialog);
        okButton.Render();
    }

    // Example of a callback
    public void CloseDialog()
    {
        Console.WriteLine("Dialog closed.");
    }
}

// Concrete creators override the factory method to change the
// resulting product's type.
class WindowsDialog : Dialog
{
    public override IButton CreateButton()
    {
        return new WindowsButton();
    }
}

class WebDialog : Dialog
{
    public override IButton CreateButton()
    {
        return new HtmlButton();
    }
}

// The product interface declares the operations that all
// concrete products must implement.
public interface IButton
{
    void Render();
    void OnClick(Action action);
}

// Concrete products provide various implementations of the
// product interface.
class WindowsButton : IButton
{
    public void Render()
    {
        // Render a button in Windows style.
        Console.WriteLine("Render Windows button.");
    }

    public void OnClick(Action action)
    {
        // Bind a native OS click event.
        action();
    }
}

class HtmlButton : IButton
{
    public void Render()
    {
        // Return an HTML representation of a button.
        Console.WriteLine("Render HTML button.");
    }

    public void OnClick(Action action)
    {
        // Bind a web browser click event.
        action();
    }
}

// Application class
class Application
{
    private Dialog dialog;

    // The application picks a creator's type depending on the
    // current configuration or environment settings.
    public void Initialize()
    {
        // Simulate reading config, for example.
        string configOS = ReadApplicationConfigFile();

        if (configOS == "Windows")
        {
            dialog = new WindowsDialog();
        }
        else if (configOS == "Web")
        {
            dialog = new WebDialog();
        }
        else
        {
            throw new Exception("Error! Unknown operating system.");
        }
    }

    // The client code works with an instance of a concrete
    // creator, albeit through its base interface. As long as
    // the client keeps working with the creator via the base
    // interface, you can pass it any creator's subclass.
    public void Main()
    {
        Initialize();
        dialog.Render();
    }

    // Simulate reading configuration
    private string ReadApplicationConfigFile()
    {
        // For demonstration, return "Windows" or "Web" based on preference
        return "Windows"; // Change this to "Web" for web version
    }
}

// Usage example
class Program
{
    static void Main(string[] args)
    {
        Application app = new Application();
        app.Main();
    }
}
