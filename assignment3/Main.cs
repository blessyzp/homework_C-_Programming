using myTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    public class Program {
        static void Main(string[] args)
        {
            Random rand = new Random();
            double totalArea = 0.0;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Shape shape;
                    switch (rand.Next(4))
                    {
                        case 0:
                            shape = ShapeFactory.CreateShape("rectangle", rand.Next(1, 10), rand.Next(1, 10));
                            break;
                        case 1:
                            shape = ShapeFactory.CreateShape("square", rand.Next(1, 10));
                            break;
                        case 2:
                            shape = ShapeFactory.CreateShape("circle", rand.Next(1, 10));
                            break;
                        default:
                            shape = ShapeFactory.CreateShape("triangle", rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10));
                            break;
                    }
                    if (shape.valid())
                    {
                        double area = shape.getArea();
                        Console.WriteLine($"Shape {shape.name}_{i + 1} Area: {area}");
                        totalArea += area;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Total Area of Shapes: {totalArea}");




        }
    }
}
