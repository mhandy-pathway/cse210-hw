using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red", 4);
        Rectangle rectangle = new Rectangle("Yellow", 3, 7);
        Circle circle = new Circle("Blue", 5);

        List<Shape> shapeList = new List<Shape>([square, rectangle, circle]);

        foreach (Shape shape in shapeList)
        {
            Console.WriteLine($"{shape.GetType().Name} - Color: {shape.GetColor()} - Area: {shape.GetArea()}");
        }
    }
}