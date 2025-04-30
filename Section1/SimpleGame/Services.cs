using System;

namespace SimpleGame
{
    public class Services
    {
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
