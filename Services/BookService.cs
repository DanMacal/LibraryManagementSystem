﻿using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Services
{
    public class BookService
    {
        private readonly List<Book> Books;
        private readonly List<BorrowTransaction> Transactions;
        public BookService(List<Book> books, List<BorrowTransaction> transactions)
        {
            Books = books;
            Transactions = transactions;
        }



        // Add/Create 
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

            Console.WriteLine("Enter ISBN:");
            string isbn = Console.ReadLine();

            Book newBook = new Book(title, author, selectedGenre, isbn);

            AddBook(newBook);
        }



        // Search 
        public List<Book> SearchBook(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Search query cannot be empty.");
                return new List<Book>();
            }

            List<Book> matchingBooks = Books.FindAll(b =>
                b.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                b.Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                b.Genre.ToString().IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
            );

            return matchingBooks;
        }



        // Update 
        public bool UpdateBookTitle(string oldTitle, string newTitle)
        {
            var book = Books.Find(b => b.Title.Equals(oldTitle, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.UpdateTitle(newTitle);
                return true;
            }
            return false;
        }


        public bool UpdateBookAuthor(string title, string newAuthor)
        {
            var book = Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.UpdateAuthor(newAuthor);
                return true;
            }
            return false;
        }


        public bool UpdateBookGenre(string title, Genre newGenre)
        {
            var book = Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.UpdateGenre(newGenre);
                return true;
            }
            return false;
        }


        public bool UpdateBookDetails(string title, string newAuthor, Genre? newGenre)
        {
            var book = Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.UpdateBookDetails(newAuthor, newGenre);
                return true;
            }
            return false;
        }



        // Remove 
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



        // Details 
        public void ShowBookDetails()
        {
            ListBooks();

            Console.Write("Enter the number of the book to view details: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= Books.Count)
            {
                var selectedBook = Books[index - 1];
                Console.Clear();
                Console.WriteLine($"Title: {selectedBook.Title}");
                Console.WriteLine($"Author: {selectedBook.Author}");
                Console.WriteLine($"Genre: {selectedBook.Genre}");
                Console.WriteLine($"ISBN: {selectedBook.ISBN}");
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a valid book number.");
            }
        }



        // List 
        public void ListBooks()
        {
            Console.Clear();

            if (Books.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
                return;
            }

            Console.WriteLine("Books in the Library:");
            foreach (var book in Books)
            {
                bool isBorrowed = Transactions.Any(t => t.BorrowedBook.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase) && !t.ReturnDate.HasValue);

                if (isBorrowed)
                {
                    Console.WriteLine($"- (Borrowed) {book.Title} by {book.Author}");
                }
                else
                {
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                }
            }
        }


        private bool IsValidBook(Book book)
        {
            return book != null && !string.IsNullOrEmpty(book.Title) && !string.IsNullOrEmpty(book.ISBN) && !string.IsNullOrEmpty(book.Author);
        }


    }
}
