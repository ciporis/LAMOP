using System;

namespace PoweredTwo_1_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberForPowering = 2;

            int leftRandomBorder = 0;
            int rightRandomBorder = 5000;

            ModifiedRandom random = new ModifiedRandom();
            int randomNumber = random[leftRandomBorder, rightRandomBorder];

            int power = 0;

            while (GetPoweredNumber(numberForPowering, power) <= randomNumber)
            {
                power++;
                Console.WriteLine($"{power}: {GetPoweredNumber(numberForPowering, power)}");
            }
            Console.WriteLine($"Number: {randomNumber}");
            Console.WriteLine($"Power: {power}");
            Console.WriteLine($"Powered number: {GetPoweredNumber(numberForPowering, power)}");
        }

        private static int GetPoweredNumber(int number, int power)
        {
            int poweredNumber = number;

            if (power == 0)
                return 1;

            if (power == 1) 
                return number;

            for (int i = 0; i < power - 1; i++)
                poweredNumber *= number;

            return poweredNumber;
        }
    }

    public class ModifiedRandom
    {
        private Random _random = new Random();

        public int this[int min, int max]
        {
            get {  return _random.Next(min, max + 1);}
        }
    }
}
