using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();
        
        // Add shapes to the list
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        // Iterate and display the color and area of each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.Color}");
            Console.WriteLine($"Area: {shape.GetArea()}");
            Console.WriteLine();
        }

        // Wait for the user to press Enter to close the application.
        Console.ReadLine();
    }
}
