using System;
using System.Numerics;

namespace myTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //输入数据
            int[][] matrix = { [1, 2, 3, 4], [5, 1, 2, 3], [9, 5, 1, 2] };
            int m = 3, n = 4; //行为m，列为n
            bool Toeplitz = true;
            int x = 0, y = 0;
            int goal = matrix[0][0];

            //检验是否为托普利茨矩阵

            //上三角
            for (int i = 0; i < m; i++)
            {
                goal = matrix[0][i];
                y = 0;
                x = i;
                while(y < m && x < n)
                {
                    
                    if (matrix[y][x] != goal)
                    {
                        Toeplitz = false;
                        break;
                    }
                    x++;
                    y++;
                }
            }

            //下三角
            for (int i = 0; i < m; i++)
            {
                goal = matrix[i][0];
                y = i;
                x = 0;
                while (y < m && x < n)
                {

                    if (matrix[y][x] != goal)
                    {
                        Toeplitz = false;
                        break;
                    }
                    x++;
                    y++;
                }
            }
        Console.Write($"{Toeplitz} ");

        return;
        }


    }
}
