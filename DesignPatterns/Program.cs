using System;
using System.Collections.Generic;

// Originator class: Sigorta poliçesi bilgilerini yönetir
public class Policy
{
    public string PolicyNumber { get; set; }
    public string PolicyHolder { get; set; }
    public decimal PremiumAmount { get; set; }

    // Mevcut durumu Memento'da saklar
    public PolicyMemento Save()
    {
        return new PolicyMemento(PolicyNumber, PolicyHolder, PremiumAmount);
    }

    // Memento'dan geri yükleme yapar
    public void Restore(PolicyMemento memento)
    {
        PolicyNumber = memento.SavedPolicyNumber;
        PolicyHolder = memento.SavedPolicyHolder;
        PremiumAmount = memento.SavedPremiumAmount;
    }

    // Poliçe detaylarını yazdıran bir metod
    public void ShowPolicyDetails()
    {
        Console.WriteLine($"Policy Number: {PolicyNumber}, Policy Holder: {PolicyHolder}, Premium: {PremiumAmount}");
    }
}

// Memento class: Poliçenin bir kopyasını saklar
public class PolicyMemento
{
    public string SavedPolicyNumber { get; private set; }
    public string SavedPolicyHolder { get; private set; }
    public decimal SavedPremiumAmount { get; private set; }

    public PolicyMemento(string policyNumber, string policyHolder, decimal premiumAmount)
    {
        SavedPolicyNumber = policyNumber;
        SavedPolicyHolder = policyHolder;
        SavedPremiumAmount = premiumAmount;
    }
}

// Caretaker class: Poliçe mementolarını yönetir
public class PolicyHistory
{
    private Stack<PolicyMemento> _policyHistory = new Stack<PolicyMemento>();

    // Memento'yu saklar
    public void Save(PolicyMemento memento)
    {
        _policyHistory.Push(memento);
    }

    // Memento'dan geri yükleme yapar
    public PolicyMemento Undo()
    {
        if (_policyHistory.Count > 0)
        {
            return _policyHistory.Pop();
        }
        return null; // Geri alınacak bir durum yoksa null döner
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Originator: Poliçe nesnesi
        Policy policy = new Policy
        {
            PolicyNumber = "AXA123",
            PolicyHolder = "John Doe",
            PremiumAmount = 1000
        };

        // Caretaker: Poliçe geçmişini yöneten sınıf
        PolicyHistory history = new PolicyHistory();

        // Poliçenin ilk halini kaydet
        history.Save(policy.Save());

        // Poliçe üzerinde değişiklik yapalım
        policy.PremiumAmount = 1200;
        policy.PolicyHolder = "Jane Doe";

        Console.WriteLine("Poliçe güncellendikten sonra:");
        policy.ShowPolicyDetails(); // Güncellenmiş poliçeyi göster

        // Poliçenin bu halini de kaydet
        history.Save(policy.Save());

        // Bir hata oldu ve geri alma yapmak istiyoruz
        Console.WriteLine("\nGeri alınıyor...");
        policy.Restore(history.Undo());

        // İlk haline geri dönmüş poliçeyi göster
        policy.ShowPolicyDetails();
    }
}
