using myTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    public static class ShapeFactory
    {
        public static Shape CreateShape(string shapeType, params double[] args)
        {
            switch (shapeType.ToLower())
            {
                case "rectangle":
                    if (args.Length != 2) throw new ArgumentException("Rectangle needs 2 parameters");
                    return new Rectangle (args[0], args[1] );
                case "square":
                    if (args.Length != 1) throw new ArgumentException("Square needs 1 parameters");
                    return new Square (args[0]);
                case "triangle":
                    if (args.Length != 3) throw new ArgumentException("Triangle needs 3 parameters");
                    return new Triangle(args[0], args[1], args[2]);
                case "circle":
                    if (args.Length != 1) throw new ArgumentException("Circle needs 1 parameters");
                    return new Circle(args[0]);
                default:
                    throw new ArgumentException("Invalid shape type");

            }

        }

    }
}
