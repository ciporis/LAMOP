using System.Runtime.CompilerServices;

namespace Repeats_2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int leftRandomBorder = 0;
            int rightRandomBorder = 100;

            int randomNumber = InclusiveRandom.InclusiveNext();
        }

        public static class InclusiveRandom
        {
            private static Random s_random = new Random();

            public static int InclusiveNext(int min, int max)
            {
                return s_random.Next(min, max + 1);
            }
        }
    }
}