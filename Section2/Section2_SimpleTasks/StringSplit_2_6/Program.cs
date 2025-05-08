using System;

namespace StringSplit_2_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку для разделения:");
            string userString = Console.ReadLine();

            string[] splittedUserString = userString.Split(' ');

            foreach (var item in splittedUserString)
            {
                Console.WriteLine(item);
            }
        }
    }
}
