using System;
using System.Collections.Generic;

namespace Library_5_4
{
    internal class Library
    {
        private readonly List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(int index)
        {
            _books.RemoveAt(index - 1);
        }

        public void ShowBooks()
        {
            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_books[i].GetInfoForDisplaying()}");
            }
        }

        public string FindBookIdByParameter(string searchParameter, string errorMessageForDisplaying)
        {
            foreach(Book book in _books)
            {
                if(book.Title == searchParameter || 
                    book.Author == searchParameter || 
                    book.PublishingYear == searchParameter)
                {
                    return book.GetInfoForDisplaying();
                }
            }

            return errorMessageForDisplaying;
        }

        public int GetLibraryCapasity()
        {
            return _books.Count;
        }
    }
}