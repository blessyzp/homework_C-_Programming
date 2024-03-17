using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace myTask
{
    public interface Shape
    {
        bool valid();//检验形状是否合法
        double getArea();//面积
    }

    //矩形（长方形）
    public class Rectangle : Shape
    {
        public double Width { set; get;}
        public double Length { set; get; }

        virtual public bool valid()
        {
        if (Width <= 0 || Length <= 0) return false;
            return true;
        }
        public double getArea()
        {
            if (!valid())
            {
                throw new ArgumentException("该形状不合法！");
                return 0.0;
            }

            return Width * Length;

        }
    }

    //正方形,继承“类”型
    /*    public class Square: Rectangle
        {
            override public bool valid()
            {
                if (Width != Length) return false;
                return true;
            }

        }*/

    //正方形,继承“接口”型
    public class Square : Shape
    {

        public double Length { get; set; }
        public bool valid()
        {
            if (Length <= 0) return false;
            return true;
        }
        public double getArea()
        {
            if (!valid())
            {
                throw new ArgumentException("该形状不合法！");
                return 0.0;
            }
            return Length * Length;

        }
    }

    //三角形
    public class Triangle : Shape
    {

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public bool valid()
        {
            if (A <= 0 || B <= 0 || C <= 0) return false;
            double max = A > B ? A : B;
            max = max > C ? max : C;
            if (A + B + C <= 2 * max) return false;
            return true;
        }
        public double getArea()
        {
            if (!valid())
            {
                throw new ArgumentException("该形状不合法！");
                return 0.0;
            }

            double p = (A + B + C) / 2;
            double s = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            return s;

        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            double totalArea = 0.0;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Shape shape;
                    switch (rand.Next(3))
                    {
                        case 0:
                            shape = ShapeFactory.CreateShape("rectangle", rand.Next(1, 10), rand.Next(1, 10));
                            break;
                        case 1:
                            shape = ShapeFactory.CreateShape("square", rand.Next(1, 10));
                            break;
                        default:
                            shape = ShapeFactory.CreateShape("triangle", rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10));
                            break;
                    }
                    if (shape.valid())
                    {
                        double area = shape.getArea();
                        Console.WriteLine($"Shape {i + 1} Area: {area}");
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

    //ShapeFactory类

    public static class ShapeFactory
    {
        public static Shape CreateShape(string shapeType, params double[] args) 
        {
            switch (shapeType.ToLower())
            {
                case "rectangle":
                    if (args.Length != 2) throw new ArgumentException("Rectangle needs 2 parameters");
                    return new Rectangle { Width = args[0], Length = args[1] };
                case "square":
                    if (args.Length != 1) throw new ArgumentException("Rectangle needs 1 parameters");
                    return new Rectangle { Length = args[0] };
                case "triangle":
                    if (args.Length != 3) throw new ArgumentException("Rectangle needs 3 parameters");
                    return new Triangle { A = args[0], B = args[1], C = args[2] };
                default:
                    throw new ArgumentException("Invalid shape type");

            }

        }

    }


}
