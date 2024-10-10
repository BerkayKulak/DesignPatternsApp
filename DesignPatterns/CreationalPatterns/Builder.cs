//using System;

//// The Car class represents a complex product. It may contain a variety of parts.
//public class Car
//{
//    public void SetSeats(int number)
//    {
//        // Set the number of seats in the car.
//        Console.WriteLine($"Setting {number} seats.");
//    }

//    public void SetEngine(string engine)
//    {
//        // Set the engine type.
//        Console.WriteLine($"Installing {engine} engine.");
//    }

//    public void SetTripComputer(bool hasTripComputer)
//    {
//        if (hasTripComputer)
//            Console.WriteLine("Installing trip computer.");
//        else
//            Console.WriteLine("No trip computer.");
//    }

//    public void SetGPS(bool hasGPS)
//    {
//        if (hasGPS)
//            Console.WriteLine("Installing GPS.");
//        else
//            Console.WriteLine("No GPS installed.");
//    }
//}

//// The Manual class represents a different product that describes a car's configuration.
//public class Manual
//{
//    public void AddSeatsDocumentation(int number)
//    {
//        // Document car seat features.
//        Console.WriteLine($"Documenting {number} seats.");
//    }

//    public void AddEngineDocumentation(string engine)
//    {
//        // Document engine instructions.
//        Console.WriteLine($"Documenting {engine} engine.");
//    }

//    public void AddTripComputerDocumentation(bool hasTripComputer)
//    {
//        if (hasTripComputer)
//            Console.WriteLine("Documenting trip computer.");
//        else
//            Console.WriteLine("No trip computer documentation.");
//    }

//    public void AddGPSDocumentation(bool hasGPS)
//    {
//        if (hasGPS)
//            Console.WriteLine("Documenting GPS.");
//        else
//            Console.WriteLine("No GPS documentation.");
//    }
//}

//// The builder interface specifies methods for creating the different parts of the product objects.
//public interface IBuilder
//{
//    void Reset();
//    void SetSeats(int number);
//    void SetEngine(string engine);
//    void SetTripComputer(bool hasTripComputer);
//    void SetGPS(bool hasGPS);
//}

//// The concrete builder for creating Car objects.
//public class CarBuilder : IBuilder
//{
//    private Car car;

//    public CarBuilder()
//    {
//        this.Reset();
//    }

//    public void Reset()
//    {
//        this.car = new Car();
//    }

//    public void SetSeats(int number)
//    {
//        car.SetSeats(number);
//    }

//    public void SetEngine(string engine)
//    {
//        car.SetEngine(engine);
//    }

//    public void SetTripComputer(bool hasTripComputer)
//    {
//        car.SetTripComputer(hasTripComputer);
//    }

//    public void SetGPS(bool hasGPS)
//    {
//        car.SetGPS(hasGPS);
//    }

//    public Car GetProduct()
//    {
//        Car product = this.car;
//        this.Reset();
//        return product;
//    }
//}

//// The concrete builder for creating Manual objects.
//public class CarManualBuilder : IBuilder
//{
//    private Manual manual;

//    public CarManualBuilder()
//    {
//        this.Reset();
//    }

//    public void Reset()
//    {
//        this.manual = new Manual();
//    }

//    public void SetSeats(int number)
//    {
//        manual.AddSeatsDocumentation(number);
//    }

//    public void SetEngine(string engine)
//    {
//        manual.AddEngineDocumentation(engine);
//    }

//    public void SetTripComputer(bool hasTripComputer)
//    {
//        manual.AddTripComputerDocumentation(hasTripComputer);
//    }

//    public void SetGPS(bool hasGPS)
//    {
//        manual.AddGPSDocumentation(hasGPS);
//    }

//    public Manual GetProduct()
//    {
//        Manual product = this.manual;
//        this.Reset();
//        return product;
//    }
//}

//// The Director is responsible for executing the building steps in a particular sequence.
//public class Director
//{
//    public void ConstructSportsCar(IBuilder builder)
//    {
//        builder.Reset();
//        builder.SetSeats(2);
//        builder.SetEngine("SportEngine");
//        builder.SetTripComputer(true);
//        builder.SetGPS(true);
//    }

//    public void ConstructSUV(IBuilder builder)
//    {
//        builder.Reset();
//        builder.SetSeats(5);
//        builder.SetEngine("SUVEngine");
//        builder.SetTripComputer(false);
//        builder.SetGPS(true);
//    }
//}

//// The client code creates a builder object, passes it to the Director, and then initiates the construction process.
//class Application
//{
//    public static void Main(string[] args)
//    {
//        Director director = new Director();

//        // Create a car
//        CarBuilder carBuilder = new CarBuilder();
//        director.ConstructSportsCar(carBuilder);
//        Car car = carBuilder.GetProduct();

//        // Create a manual for the car
//        CarManualBuilder manualBuilder = new CarManualBuilder();
//        director.ConstructSportsCar(manualBuilder);
//        Manual manual = manualBuilder.GetProduct();

//        // Output car details and manual creation to the console
//        Console.WriteLine("Car and Manual created.");
//    }
//}
