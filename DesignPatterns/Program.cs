using System;

// Mediator interface
public interface IMediator
{
    void Notify(object sender, string ev);
}

// Concrete Mediator (PolicyManagementMediator)
public class PolicyManagementMediator : IMediator
{
    private Dropdown _policyTypeDropdown;
    private Textbox _customerName;
    private Textbox _policyNumber;
    private Textbox _healthDetails;
    private Textbox _vehicleDetails;
    private Button _submitButton;

    public PolicyManagementMediator()
    {
        // Bileşenler oluşturulur ve mediator atanır
        _policyTypeDropdown = new Dropdown(this);
        _customerName = new Textbox(this);
        _policyNumber = new Textbox(this);
        _healthDetails = new Textbox(this);
        _vehicleDetails = new Textbox(this);
        _submitButton = new Button(this);
    }

    public void Notify(object sender, string ev)
    {
        if (sender == _policyTypeDropdown && ev == "change")
        {
            string selectedPolicy = _policyTypeDropdown.GetSelectedOption();
            if (selectedPolicy == "Health")
            {
                ShowHealthPolicyForm();
                HideVehiclePolicyForm();
            }
            else if (selectedPolicy == "Vehicle")
            {
                ShowVehiclePolicyForm();
                HideHealthPolicyForm();
            }
        }

        if (sender == _submitButton && ev == "click")
        {
            string policyType = _policyTypeDropdown.GetSelectedOption();
            Console.WriteLine("Submitting " + policyType + " policy for customer: " + _customerName.Text);
        }
    }

    private void ShowHealthPolicyForm()
    {
        Console.WriteLine("Showing Health Policy form.");
        _healthDetails.Visible = true;
    }

    private void HideHealthPolicyForm()
    {
        Console.WriteLine("Hiding Health Policy form.");
        _healthDetails.Visible = false;
    }

    private void ShowVehiclePolicyForm()
    {
        Console.WriteLine("Showing Vehicle Policy form.");
        _vehicleDetails.Visible = true;
    }

    private void HideVehiclePolicyForm()
    {
        Console.WriteLine("Hiding Vehicle Policy form.");
        _vehicleDetails.Visible = false;
    }
}

// Base component class
public class Component
{
    protected IMediator _mediator;

    public Component(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Click()
    {
        _mediator.Notify(this, "click");
    }

    public void Change()
    {
        _mediator.Notify(this, "change");
    }
}

// Dropdown component
public class Dropdown : Component
{
    private string _selectedOption;

    public Dropdown(IMediator mediator) : base(mediator) { }

    public void SelectOption(string option)
    {
        _selectedOption = option;
        Change();
    }

    public string GetSelectedOption()
    {
        return _selectedOption;
    }
}

// Textbox component
public class Textbox : Component
{
    public string Text { get; set; }
    public bool Visible { get; set; }

    public Textbox(IMediator mediator) : base(mediator)
    {
        Visible = true;
    }
}

// Button component
public class Button : Component
{
    public Button(IMediator mediator) : base(mediator) { }
}

// Client code (Main program)
class Program
{
    static void Main(string[] args)
    {
        PolicyManagementMediator mediator = new PolicyManagementMediator();

        // Kullanıcı Sağlık Sigortası seçiyor
        Console.WriteLine("User selected Health Policy:");
        Dropdown policyDropdown = new Dropdown(mediator);
        policyDropdown.SelectOption("Health");
        Button submitButton = new Button(mediator);
        submitButton.Click();

        // Kullanıcı Araç Sigortası seçiyor
        Console.WriteLine("\nUser selected Vehicle Policy:");
        policyDropdown.SelectOption("Vehicle");
        submitButton.Click();
    }
}
