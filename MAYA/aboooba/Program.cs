using System;

namespace aboooba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int rows = 30;
            int min = 0;
            int max = 101;

            int[] nums = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                nums[i] = random.Next(min, max);
                Console.Write(nums[i]+"\t");
            }


        }
    }
}
