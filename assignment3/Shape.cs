using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace myTask
{
    public interface Shape
    {
        bool valid();//检验形状是否合法
        double getArea();//面积

        string name { get;  }
    }
}
