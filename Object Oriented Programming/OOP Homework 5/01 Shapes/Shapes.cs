using System;

namespace _01_Shapes
{
    class Shapes
    {
        static void Main()
        {
            Console.WriteLine("Task 01 - Shapes implementation\r\n");

            Shape[] shapes = new Shape[] // creates a List of different shapes
            {
                new Triangle(5,5),
                new Rectangle(5,5),
                new Circle(5),
                new Triangle(5,4),
                new Rectangle(5,4),
                new Circle(4),
                new Triangle(4,6),
                new Rectangle(4,6),
                new Circle(6),
                new Triangle(5,15),
                new Rectangle(15,5),
                new Circle(15),
                new Triangle(3,3),
                new Rectangle(8,8),
                new Circle(8),
                new Triangle(9,3),
                new Triangle(3,9),
                new Triangle(5,9),
                new Circle(11),
                new Circle(12),
                new Triangle(5,1),
                new Triangle(1,5),
                new Triangle(7,5),
            };

            foreach (Shape item in shapes) // prints all shapes on the console
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
