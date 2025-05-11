using System;
using System.Collections.Generic;

namespace Queue_4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clientsSumms = { 180, 999, 100, 156, -11, 6666, 1440 };

            Queue<int> billsSumms = new Queue<int>();

            foreach (int i in clientsSumms)
                billsSumms.Enqueue(i);

            int myBalance = 0;

            string userInput;

            string accesCommand = "y";
            string resqueCommand = "n";

            while(billsSumms.Count > 0)
            {
                Console.Clear();

                Console.WriteLine($"Текущий баланс нашей конторы: {myBalance}");

                Console.WriteLine($"Итак, подтвеждаете покупку на {billsSumms.Peek()} денег");
                Console.WriteLine($"{accesCommand} - yes, {resqueCommand} - no");

                userInput = Console.ReadLine();

                if(userInput == accesCommand)
                    myBalance += billsSumms.Dequeue();
                else
                    billsSumms.Dequeue();
            }
        }
    }
}