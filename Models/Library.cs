using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSysyem.Models
{
    class Library
    {
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }

        public Library(Book book)
        {
            Books = new List<Book>() { book };
            Users = new List<User>();
        }

        public Library(User user)
        {
            Books = new List<Book>();
            Users = new List<User>() { user };
        }

        public Library(List<Book> books, List<User> users)
        {
            Books = books;
            Users = users;
        }


        //Book Methods
        public void AddBook(Book book)
        {
            if (IsValidBook(book))
            {
                Books.Add(book);
                Console.WriteLine($"{book} has been successfully added.");
            }
            else
            {
                Console.WriteLine("Please enter a valid book.");
            }
        }

        public void RemoveBook()
        {
            ListBooks();

            if (Books.Count == 0) return;

            Console.WriteLine("\nEnter the number of the item to remove:");
            if (int.TryParse(Console.ReadLine(), out int removeIndex) &&
                removeIndex > 0 &&
                removeIndex <= Books.Count)
            {
                Console.WriteLine();
                Console.WriteLine($"Item '{Books[removeIndex - 1]}' removed successfully.");
                Books.RemoveAt(removeIndex - 1);
            }
            else
            {
                Console.WriteLine("Please enter a valid book number.");
            }
        }

        public void ListBooks()
        {
            Console.Clear();
            Console.WriteLine("Books in Library:");

            if (Books.Count == 0)
            {
                Console.WriteLine("No books to display.");
            }
            else
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Books[i]}");
                }
            }
        }

        private bool IsValidBook(Book book)
        {
            return book != null && !string.IsNullOrEmpty(book.Title) && book.ISBN > 0 && !string.IsNullOrEmpty(book.Author);
        }
    }
}
