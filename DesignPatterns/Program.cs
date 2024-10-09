using System;
using System.Collections.Generic;

// Abstract class Shape
public abstract class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Color { get; set; }

    // Regular constructor
    public Shape() { }

    // Prototype constructor
    public Shape(Shape source)
    {
        if (source != null)
        {
            this.X = source.X;
            this.Y = source.Y;
            this.Color = source.Color;
        }
    }

    // The clone method
    public abstract Shape Clone();
}

// Concrete prototype: Rectangle
public class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    // Constructor for Rectangle
    public Rectangle() { }

    // Prototype constructor for Rectangle
    public Rectangle(Rectangle source) : base(source)
    {
        if (source != null)
        {
            this.Width = source.Width;
            this.Height = source.Height;
        }
    }

    // Clone method for Rectangle
    public override Shape Clone()
    {
        return new Rectangle(this);
    }
}

// Concrete prototype: Circle
public class Circle : Shape
{
    public int Radius { get; set; }

    // Constructor for Circle
    public Circle() { }

    // Prototype constructor for Circle
    public Circle(Circle source) : base(source)
    {
        if (source != null)
        {
            this.Radius = source.Radius;
        }
    }

    // Clone method for Circle
    public override Shape Clone()
    {
        return new Circle(this);
    }
}

// Client code: Application
public class Application
{
    private List<Shape> shapes = new List<Shape>();

    public Application()
    {
        // Create and clone a Circle
        Circle circle = new Circle();
        circle.X = 10;
        circle.Y = 10;
        circle.Radius = 20;
        shapes.Add(circle);

        Circle anotherCircle = (Circle)circle.Clone();
        shapes.Add(anotherCircle);

        // Create and clone a Rectangle
        Rectangle rectangle = new Rectangle();
        rectangle.X = 5;
        rectangle.Y = 5;
        rectangle.Width = 10;
        rectangle.Height = 20;
        shapes.Add(rectangle);
    }

    public void BusinessLogic()
    {
        // Create a copy of the shapes list
        List<Shape> shapesCopy = new List<Shape>();

        foreach (var shape in shapes)
        {
            shapesCopy.Add(shape.Clone());
        }

        // Now shapesCopy contains clones of the original shapes
    }
}

// Example usage
public class Program
{
    public static void Main(string[] args)
    {
        Application app = new Application();
        app.BusinessLogic();
        Console.WriteLine("Shapes copied successfully.");
    }
}
