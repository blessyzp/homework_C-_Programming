
using System;
using System.Numerics;

namespace myWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //接收数据
            Program program = new Program();
            int num = program.receive();
            int ansCount = 0;
            bool haveBeenCout = false;

            //处理数据,判断并输出
            for (int i = 2; i <= num;)
            {
                if (i > Math.Pow(num, 0.5)) break;
                if (num % i == 0)
                {
                    num = num / i;
                    if (!haveBeenCout)
                    {
                        //输出数据
                        program.output($"{i}");
                        haveBeenCout = true;
                    }

                }
                else
                {
                    i++;
                }

            }
            if (num != 1) Console.WriteLine($"{num}");


        }

        //读取数据
        public int receive()
        {
            Console.Write("Please input one int number: ");
            string keyboardIn = "";
            keyboardIn = Console.ReadLine();
            return int.Parse(keyboardIn);
        }

        public int output(string str)
        {
            Console.WriteLine($"{str}");
            return 0;
        }


    }



}
