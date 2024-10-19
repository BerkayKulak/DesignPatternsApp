//using System;
//using System.Collections.Generic;

//// The collection interface declares a factory method for producing iterators.
//interface ISocialNetwork
//{
//    IProfileIterator CreateFriendsIterator(string profileId);
//    IProfileIterator CreateCoworkersIterator(string profileId);
//}

//// The iterator interface declares methods for traversing a collection.
//interface IProfileIterator
//{
//    bool HasMore();
//    Profile GetNext();
//}

//// The concrete iterator class implements traversal logic for a specific collection.
//class FacebookIterator : IProfileIterator
//{
//    private Facebook _facebook;
//    private string _profileId;
//    private string _type;
//    private int _currentPosition;
//    private List<Profile> _cache;

//    public FacebookIterator(Facebook facebook, string profileId, string type)
//    {
//        _facebook = facebook;
//        _profileId = profileId;
//        _type = type;
//        _currentPosition = 0;
//        _cache = null;
//    }

//    // Initializes the cache lazily
//    private void LazyInit()
//    {
//        if (_cache == null)
//        {
//            _cache = _facebook.SocialGraphRequest(_profileId, _type);
//        }
//    }

//    public bool HasMore()
//    {
//        LazyInit();
//        return _currentPosition < _cache.Count;
//    }

//    public Profile GetNext()
//    {
//        if (HasMore())
//        {
//            return _cache[_currentPosition++];
//        }
//        return null;
//    }
//}

//// The concrete collection class implements the collection interface and returns specific iterators.
//class Facebook : ISocialNetwork
//{
//    public IProfileIterator CreateFriendsIterator(string profileId)
//    {
//        return new FacebookIterator(this, profileId, "friends");
//    }

//    public IProfileIterator CreateCoworkersIterator(string profileId)
//    {
//        return new FacebookIterator(this, profileId, "coworkers");
//    }

//    // Simulate a request to Facebook's database
//    public List<Profile> SocialGraphRequest(string profileId, string type)
//    {
//        // In a real-world scenario, this method would make an API call to Facebook.
//        // Here we'll simulate the return of a list of profiles.
//        return new List<Profile>
//        {
//            new Profile("1", "John Doe", "john.doe@example.com"),
//            new Profile("2", "Jane Smith", "jane.smith@example.com"),
//            new Profile("3", "Emily Johnson", "emily.johnson@example.com")
//        };
//    }
//}

//// The Profile class represents an individual profile.
//class Profile
//{
//    public string Id { get; }
//    public string Name { get; }
//    public string Email { get; }

//    public Profile(string id, string name, string email)
//    {
//        Id = id;
//        Name = name;
//        Email = email;
//    }

//    public string GetEmail()
//    {
//        return Email;
//    }
//}

//// The SocialSpammer class uses an iterator to send spam messages.
//class SocialSpammer
//{
//    public void Send(IProfileIterator iterator, string message)
//    {
//        while (iterator.HasMore())
//        {
//            Profile profile = iterator.GetNext();
//            Console.WriteLine($"Sending email to {profile.GetEmail()}: {message}");
//        }
//    }
//}

//// The application class configures collections and iterators and then passes them to the client code.
//class Application
//{
//    private ISocialNetwork _network;
//    private SocialSpammer _spammer;

//    public void Config(bool useFacebook)
//    {
//        if (useFacebook)
//        {
//            _network = new Facebook();
//        }
//        // LinkedIn or other social networks can be added similarly.

//        _spammer = new SocialSpammer();
//    }

//    public void SendSpamToFriends(string profileId)
//    {
//        IProfileIterator iterator = _network.CreateFriendsIterator(profileId);
//        _spammer.Send(iterator, "Hey, don't miss this opportunity!");
//    }

//    public void SendSpamToCoworkers(string profileId)
//    {
//        IProfileIterator iterator = _network.CreateCoworkersIterator(profileId);
//        _spammer.Send(iterator, "Join our upcoming work event!");
//    }
//}

//// Client code
//class Program
//{
//    static void Main(string[] args)
//    {
//        Application app = new Application();
//        app.Config(true);

//        Console.WriteLine("Sending spam to friends:");
//        app.SendSpamToFriends("profile123");

//        Console.WriteLine("\nSending spam to coworkers:");
//        app.SendSpamToCoworkers("profile123");
//    }
//}
