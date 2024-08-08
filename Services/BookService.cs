using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Services
{
    public class BookService
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
                Console.WriteLine($"\n'{book.Title}' has been successfully added.");
            }
            else
            {
                Console.WriteLine("Please enter a valid book.");
            }
        }


        public void CreateBook()
        {
            Console.Clear();

            Console.WriteLine("Enter ISBN:");
            int isbn = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter Title:");
            string title = Console.ReadLine();

            Console.WriteLine("\nEnter Author:");
            string author = Console.ReadLine();

            Console.WriteLine("\nSelect Genre:");
            foreach (var genre in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{(int)genre}. {genre}");
            }

            Genre selectedGenre;
            while (true)
            {
                Console.WriteLine("\nEnter the number corresponding to the genre:");
                if (int.TryParse(Console.ReadLine(), out int genreInput) && Enum.IsDefined(typeof(Genre), genreInput))
                {
                    selectedGenre = (Genre)genreInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }


            Book newBook = new Book(title, isbn, author, selectedGenre);

            AddBook(newBook);
        }


        public List<Book> SearchBook(string query)
        {
            // Validate the query
            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Search query cannot be empty.");
                return new List<Book>();
            }

            // Search for books that match the query
            List<Book> matchingBooks = Books.FindAll(b =>
                b.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                b.Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                b.Genre.ToString().IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
            );

            return matchingBooks;
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
                Console.WriteLine($"Item {Books[removeIndex - 1]} removed successfully.");
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

            if (Books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Books[i].Title}");
            }
        }


        private bool IsValidBook(Book book)
        {
            return book != null && !string.IsNullOrEmpty(book.Title) && book.ISBN > 0 && !string.IsNullOrEmpty(book.Author);
        }


    }
}
