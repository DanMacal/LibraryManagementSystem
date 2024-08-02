using LibraryManagementSysyem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSysyem.Services
{
    class BookService
    {
        private readonly List<Book> Books;

        public BookService(List<Book> books)
        {
            Books = books;
        }


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

        public void UpdateBook(int isbn, Book updatedBook)
        {
            var book = Books.Find(b => b.ISBN == isbn);

            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Genre = updatedBook.Genre;

                Console.WriteLine($"Book with ISBN {isbn} has been successfully updated.");
            }
            else
            {
                Console.WriteLine("Book not found.");
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
