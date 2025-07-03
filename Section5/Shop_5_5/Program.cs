using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Xml.Schema;
using System.Runtime.InteropServices.WindowsRuntime;
using System.IO;

namespace Shop_5_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = 
            {
                new Product("Laptop", 650),
                new Product("Smartphone", 399),
                new Product("Headphones", 99),
                new Product("Keyboard", 49),
                new Product("Mouse", 25),
                new Product("Monitor", 199),
                new Product("Tablet", 299),
                new Product("Printer", 129),
                new Product("Speaker", 79),
                new Product("Camera", 450),
                new Product("SSD Drive", 89),
                new Product("Router", 75),
                new Product("Smartwatch", 199),
                new Product("External HDD", 59),
                new Product("USB Flash Drive", 15)
            };

            Shop shop = new Shop(products);
            ServiceLocator.Register(shop);

            Console.WriteLine("Enter customers count:");
            int cusomersCount = int.Parse(Console.ReadLine());

            CustomersGenerator customersGenerator = new CustomersGenerator(cusomersCount);
            Customer[] customers = customersGenerator.GetCustomers();

            shop.AddQueue(customers);

            int leftCursorPos = 40;
            int topCursorPos = 0;

            const ConsoleKey Access = ConsoleKey.Y;
            const ConsoleKey Reject = ConsoleKey.N;

            for (int i = 0; i < cusomersCount; i++)
            {
                Customer currentCustomer = shop.Queue.Peek();

                Console.Clear();
                Console.SetCursorPosition(leftCursorPos, topCursorPos);
                Console.Write($"Current balance: {shop.Balance}");

                Console.SetCursorPosition(0, 0);

                Console.WriteLine($"Customer's balance: {currentCustomer.Balance}");
                Console.WriteLine($"Customer's cart:");

                for (int j = 0; j < currentCustomer.Products.Length; j++)
                {
                    Console.WriteLine($"{currentCustomer.Products[j].Name} : {currentCustomer.Products[j].Price}$");
                }

                Console.WriteLine();
                Console.WriteLine($"Total: {currentCustomer.Total}");
                Console.WriteLine();

                Console.WriteLine("Press [y] for access and [n] for reject");

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case (Access):
                        shop.Sell();
                        break;
                    case (Reject):
                        shop.Reject();
                        break;
                }
            }
        }
    }
}