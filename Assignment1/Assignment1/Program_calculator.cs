using System;

namespace myApp
{
    class Program_calculator
    {
        static void Main(string[] args)
        {
            //准备输入
            double a = 0.0, b = 0.0, c = 0.0;
            string s = "", str = "";

            //准备取数据
            Console.Write("Please input two double numbers: ");
            s = Console.ReadLine();
            a = Double.Parse(s);
            s = Console.ReadLine();
            b = Double.Parse(s);
            Console.Write("Please input the operator: ");
            while(str == "")
            {
                str = Console.ReadLine();
                if ((str != "+" && str != "-" && str != "/" && str != "*" && str != "**") || (str == "/" && b == 0) )
                {
                    if(!(str == "/" && b == 0))
                        Console.Write("The input is invalid. Please input the operator again: ");
                    else
                    {
                        Console.Write("The input is invalid. Please input the number b and operator again: ");
                        s = Console.ReadLine();
                        b = Double.Parse(s);
                    }
                    str = "";
                }

            }

            //开始处理
            switch (str)
            {
                case "+":
                    c = a + b;
                    break;
                case "-":
                    c = a - b;
                    break;
                case "*":
                    c = a * b;
                    break;
                case "/":
                    c = a / b;
                    break;
                case "**":
                    c = Math.Pow(a,b);
                    break;
                default: break;
            }

            //输出值
            Console.WriteLine($"{a} {str} {b} = {c}");

            return;
        }
    }
}
