//using System;
//using System.Collections.Generic;

//// The handler interface declares a method for executing a request.
//public interface IComponentWithContextualHelp
//{
//    void ShowHelp();
//}

//// Base class for simple components.
//public abstract class Component : IComponentWithContextualHelp
//{
//    protected string TooltipText { get; set; }
//    private Container _container; // Container that acts as the next link in the chain

//    // Public method to set the container
//    public void SetContainer(Container container)
//    {
//        _container = container;
//    }

//    // The component shows a tooltip if there's help text.
//    // Otherwise, it forwards the call to the container, if it exists.
//    public virtual void ShowHelp()
//    {
//        if (!string.IsNullOrEmpty(TooltipText))
//        {
//            Console.WriteLine($"Showing tooltip: {TooltipText}");
//        }
//        else if (_container != null)
//        {
//            _container.ShowHelp();  // Forward the call to the container
//        }
//    }
//}

//// Containers can contain both simple components and other containers.
//// Chain relationships are established here.
//public abstract class Container : Component
//{
//    protected List<Component> Children = new List<Component>();

//    public void Add(Component child)
//    {
//        Children.Add(child);
//        child.SetContainer(this);  // Use the public method to set container
//    }

//    // Public method to access the children
//    public List<Component> GetChildren()
//    {
//        return Children;
//    }
//}

//// Simple component (leaf) such as a button.
//public class Button : Component
//{
//    public Button(string tooltip)
//    {
//        this.TooltipText = tooltip;
//    }
//}

//// Complex component (composite) such as a panel that may override the default implementation.
//public class Panel : Container
//{
//    public string ModalHelpText { get; set; }

//    public override void ShowHelp()
//    {
//        if (!string.IsNullOrEmpty(ModalHelpText))
//        {
//            Console.WriteLine($"Showing modal help: {ModalHelpText}");
//        }
//        else
//        {
//            base.ShowHelp();  // Call the base implementation if no modal help
//        }
//    }
//}

//// Another complex component (composite) such as a dialog with potential wiki page help.
//public class Dialog : Container
//{
//    public string WikiPageUrl { get; set; }

//    public override void ShowHelp()
//    {
//        if (!string.IsNullOrEmpty(WikiPageUrl))
//        {
//            Console.WriteLine($"Opening wiki help page: {WikiPageUrl}");
//        }
//        else
//        {
//            base.ShowHelp();  // Forward to parent if no help is provided
//        }
//    }
//}

//// Client code.
//public class Application
//{
//    private Dialog dialog;

//    // Configures the chain of responsibility
//    public void CreateUI()
//    {
//        dialog = new Dialog();
//        dialog.WikiPageUrl = "http://help.wiki/BudgetReports";

//        Panel panel = new Panel();
//        panel.ModalHelpText = "This panel shows financial data.";

//        Button okButton = new Button("This is the OK button.");
//        Button cancelButton = new Button(null); // No tooltip for this button

//        panel.Add(okButton);
//        panel.Add(cancelButton);
//        dialog.Add(panel);
//    }

//    // When F1 key is pressed, it will check the component at mouse coordinates.
//    public void OnF1KeyPress(Component component)
//    {
//        component.ShowHelp();  // Start the chain of responsibility
//    }

//    // Simulate getting the component at mouse coordinates
//    public Component GetComponentAtMouseCoords()
//    {
//        // Casting Component to Container to access GetChildren
//        var panel = dialog.GetChildren()[0] as Container;
//        if (panel != null)
//        {
//            return panel.GetChildren()[1]; // Cancel button
//        }
//        return null;
//    }
//}

//// Main program
//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Application app = new Application();
//        app.CreateUI();

//        // Simulating F1 key press
//        Component component = app.GetComponentAtMouseCoords();
//        if (component != null)
//        {
//            app.OnF1KeyPress(component);  // This should propagate the help request up the chain
//        }
//        else
//        {
//            Console.WriteLine("No component found at mouse coordinates.");
//        }
//    }
//}
