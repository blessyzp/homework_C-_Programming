using myTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    public class Triangle : Shape
    {
        public Triangle(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }
        string Shape.name { get => "Triangle"; }
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
    }
}
