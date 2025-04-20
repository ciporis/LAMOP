using System;

namespace Password_1_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CORRECT_PASSWORD = "bobr";
            string hiddenMessage = "ALOOOOOOOOOOOOOOOOOOOOOOOOOOOOO";

            int tries = 3;

            while (tries > 0)
            {
                Console.WriteLine("Input your password");
                string userInput = Console.ReadLine();

                if (userInput != CORRECT_PASSWORD)
                {
                    Console.WriteLine("Uncrorrect password");
                    tries--;
                    continue;
                }

                Console.WriteLine(hiddenMessage);
            }
            Console.WriteLine("You used all tyes");
        }
    }
}
