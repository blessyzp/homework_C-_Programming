using myTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    public class Rectangle : Shape
    {
        public Rectangle(double Length, double Width)
        {
            this.Length = Length;
            this.Width = Width;
        }
        public double Width { set; get; }
        public double Length { set; get; }
        string Shape.name { get => "Rectangle"; }

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
            }
            return Width * Length;

        }
    }
}
