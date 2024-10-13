using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    // Flyweight interface (shared state)
    public interface IShape
    {
        void Draw(int x, int y, string uniqueState);
    }

    // Concrete Flyweight class (shared state)
    public class Circle : IShape
    {
        private string color;
        private int radius;

        public Circle(string color, int radius)
        {
            this.color = color;
            this.radius = radius;
        }

        // Intrinsic state (shared): color, radius
        // Extrinsic state (unique): x, y
        public void Draw(int x, int y, string uniqueState)
        {
            Console.WriteLine($"Drawing Circle [Color: {color}, Radius: {radius}, Position: ({x},{y})] with {uniqueState}");
        }
    }

    // Flyweight Factory: Manages the Flyweight objects and provides shared instances
    public class ShapeFactory
    {
        private Dictionary<string, IShape> shapeCache = new Dictionary<string, IShape>();

        // Returns the shared flyweight object
        public IShape GetCircle(string color, int radius)
        {
            string key = $"{color}_{radius}";

            if (!shapeCache.ContainsKey(key))
            {
                shapeCache[key] = new Circle(color, radius);
                Console.WriteLine($"Creating new Circle of color {color} and radius {radius}");
            }

            return shapeCache[key];
        }

        public int GetTotalShapesCreated()
        {
            return shapeCache.Count;
        }
    }

    // Client code that uses Flyweight objects
    public class DrawingApp
    {
        private ShapeFactory shapeFactory;

        public DrawingApp(ShapeFactory shapeFactory)
        {
            this.shapeFactory = shapeFactory;
        }

        public void DrawShapes()
        {
            // Same shape (shared) but at different positions (unique)
            var circle1 = shapeFactory.GetCircle("Red", 5);
            circle1.Draw(10, 10, "unique shading");

            var circle2 = shapeFactory.GetCircle("Red", 5);
            circle2.Draw(15, 20, "unique border");

            var circle3 = shapeFactory.GetCircle("Blue", 10);
            circle3.Draw(25, 30, "glossy texture");

            var circle4 = shapeFactory.GetCircle("Green", 7);
            circle4.Draw(35, 40, "dotted border");

            // Reuse the existing "Red" circle
            var circle5 = shapeFactory.GetCircle("Red", 5);
            circle5.Draw(50, 60, "bright shadow");
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            DrawingApp drawingApp = new DrawingApp(shapeFactory);

            drawingApp.DrawShapes();

            Console.WriteLine($"\nTotal unique shapes created: {shapeFactory.GetTotalShapesCreated()}");
        }
    }
}
