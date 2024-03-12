using System;

namespace myTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //接收数组
            Program program = new Program();
            int[] nums = program.receive();

            //最大值、最小值、平均值、和
            int max = nums[0], min = nums[0];
            double sum = 0;
            double means = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                max = max > nums[i] ? max : nums[i];
                min = min < nums[i] ? min : nums[i];
                sum += nums[i];
            }
            means = sum / nums.Length;

            //输出
            program.output(max);
            program.output(min);
            program.output(means);
            program.output(sum);


        }

        //读取数据
        public int[] receive()
        {
            Console.Write("Please input several int numbers, splitting every number with ',': ");
            char[] split = new char[] {','};
            string[] keyboardIn = Console.ReadLine().Split(split);
            int[] num_arr = new int[keyboardIn.Length];
            num_arr = Array.ConvertAll<string, int>(keyboardIn, m => int.Parse(m));
            return num_arr;
        }

        //输出数据
        public void output(int m)
        {
            Console.WriteLine($"{m}");
        }

        public void output(double m)
        {
            Console.WriteLine($"{m}");
        }
    }
}
