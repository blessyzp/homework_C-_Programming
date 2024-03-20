using myTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    public  class Circle : Shape
    {
        public Circle(double r)
        {
            this.Radius = r;
        }


        public double Radius { get; set; }
        string Shape.name { get =>"Circle";}

        public bool valid()
        {
            return Radius > 0;
        }
        public double getArea()
        {
            if(!valid()) throw new ArgumentException("该形状不合法！");
            return Math.PI * Radius * Radius;
        }

    }                       
}
