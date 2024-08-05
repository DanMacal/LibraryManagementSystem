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
                Console.WriteLine($"'{book.Title}' has been successfully added.");
            }
            else
            {
                Console.WriteLine("Please enter a valid book.");
            }
        }


        public Book SearchBook(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            return Books.Find(b =>
                b.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                b.Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                b.Genre.ToString().IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
            );
        }


        public void UpdateBook(string title, Book updatedBook)
        {
            var book = Books.Find(b => b.Title == title);

            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Genre = updatedBook.Genre;

                Console.WriteLine($"Book with ISBN {title} has been successfully updated.");
            }
            else
            {
                Console.WriteLine("Book not found.");
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
            Console.WriteLine("Books in Library:");

            if (Books.Count == 0)
            {
                Console.WriteLine("No books to display.");
            }
            else
            {
                Books.ForEach(book => Console.WriteLine(book.Title));
            }
        }


        private bool IsValidBook(Book book)
        {
            return book != null && !string.IsNullOrEmpty(book.Title) && book.ISBN > 0 && !string.IsNullOrEmpty(book.Author);
        }
    }
}
