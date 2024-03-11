using System;

namespace myTask
{
    class Program
    {
        static void Main(string[] args)
        {
            bool prime = true;
            for(int i = 2; i <= 100; i++)
            {
                prime = true;
                for (int j = 2; j < i && j <= 10; j++)
                {
                    if (i % j == 0)
                    {
                        prime = false;
                        break;
                    }

                }
                if(prime) Console.Write($"{i} ");


            }




        }

    }
}
