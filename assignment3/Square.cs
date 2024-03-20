using myTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    public class Square : Shape
    {
        public Square(double Length)
        {
            this.Length = Length;
        }
        public double Length { get; set; }
        string Shape.name { get => "Square"; }
        public bool valid()
        {
            return Length > 0;
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
}
