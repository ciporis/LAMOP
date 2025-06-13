using System;
using System.CodeDom;

namespace Library_5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book[] books =
            {
                new Book("Dune", "Pretty interesting etc", "Frank Herbert", "1965"),
                new Book("Alice in the wonderland", "Pretty interesting etc", "Lewis Carrol", "1865"),
                new Book("Clean Architecture", "Pretty interesting etc", "Robert Martin", "2024"),
            };

            bool isWorking = true;

            var library = new Library();
            var commandsService = new CommandsService();

            const string addCommand = "1";
            const string removeCommand = "2";
            const string findCommand = "3";

            int minCommandNumber = 1;
            int maxCommandNumebr = 3;

            string searchFaillureMessage = "Book is not found";

            foreach (Book book in books)
            {
                library.AddBook(book);
            }

            while (isWorking)
            {
                Console.WriteLine("Input command number");
                Console.WriteLine($"{addCommand}) Add book");
                Console.WriteLine($"{removeCommand}) Remove book");
                Console.WriteLine($"{findCommand}) Find book");

                string command = commandsService.CheckIfNumberIsCorrect(minCommandNumber, 
                    maxCommandNumebr, Console.ReadLine());

                int libraryCapasity = library.GetLibraryCapasity();

                switch (command)
                {
                    case addCommand:
                        Console.WriteLine("Input a book's title:");
                        string title = Console.ReadLine();

                        Console.WriteLine("Input a book's author:");
                        string author = Console.ReadLine();

                        Console.WriteLine("Input a book's description");
                        string description = Console.ReadLine();

                        Console.WriteLine("Input a publishment year:");
                        string publishmentYear = commandsService.CheckIfInputIsDate(Console.ReadLine());

                        Book book = new Book(title, description, author, publishmentYear);
                        library.AddBook(book);
                        break;
                    case removeCommand:
                        library.ShowBooks();
                        Console.WriteLine("\nInput book's number");
                        int bookNumber = int.Parse
                            (commandsService.CheckIfNumberIsCorrect(1, libraryCapasity, Console.ReadLine()));
                        library.RemoveBook(bookNumber);
                        break;
                    case findCommand:
                        Console.WriteLine("Search by title, author or publishment year:");
                        string bookInfo = library.FindBookIdByParameter(Console.ReadLine(), searchFaillureMessage);
                        Console.WriteLine(bookInfo);
                        break;
                }
            }
        }
    }
}
