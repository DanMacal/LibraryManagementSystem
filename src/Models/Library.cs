﻿using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Models
{
    public class Library
    {
        public List<Book> Books { get; private set; }
        public List<User> Users { get; private set; }
        public List<BorrowTransaction> Transactions { get; private set; }

        // Business Logic
        private readonly BookService bookService;
        private readonly UserService userService;
        private readonly BorrowService borrowService;

        public Library()
        {
            Books = new List<Book>();
            Users = new List<User>();
            Transactions = new List<BorrowTransaction>();
            bookService = new BookService(Books, Transactions);
            userService = new UserService(Users);
            borrowService = new BorrowService(this);
        }

        public Library(List<Book> books, List<User> users)
        {
            Books = books ?? new List<Book>();
            Users = users ?? new List<User>();
            Transactions = new List<BorrowTransaction>();
            bookService = new BookService(Books, Transactions);
            userService = new UserService(Users);
            borrowService = new BorrowService(this);
        }


        // Book methods

        // Create/Add
        public void CreateBook()
        {
            bookService.CreateBook();
        }
        public void AddBook(Book book)
        {
            bookService.AddBook(book);
        }



        // Search
        public void SearchBook(string query)
        {
            List<Book> results = bookService.SearchBook(query);

            if (results.Count == 0)
            {
                Console.WriteLine("No books found matching the query.");
            }
            else
            {
                Console.WriteLine("Search Results:");
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {results[i].Title} by {results[i].Author} (Genre: {results[i].Genre})");
                }
            }
        }



        // Update
        public bool UpdateBookTitle(string oldTitle, string newTitle)
        {
            return bookService.UpdateBookTitle(oldTitle, newTitle);
        }

        public bool UpdateBookAuthor(string title, string newAuthor)
        {
            return bookService.UpdateBookAuthor(title, newAuthor);
        }

        public bool UpdateBookGenre(string title, Genre newGenre)
        {
            return bookService.UpdateBookGenre(title, newGenre);
        }



        public bool UpdateBookDetails(string title, string newTitle, string newAuthor, Genre? newGenre)
        {
            return bookService.UpdateBookDetails(title, newTitle, newAuthor, newGenre);
        }



        // Remove
        public void RemoveBook()
        {
            bookService.RemoveBook();
        }



        // Details
        public void ShowBookDetails()
        {
            bookService.ShowBookDetails();
        }



        // List
        public void ListBooks()
        {
            bookService.ListBooks();
        }


        // User methods

        // Add/Create
        public void AddUser(User user)
        {
            userService.AddUser(user);
        }

        public void CreateUser()
        {
            userService.CreateUser();
        }


        // Search
        public void SearchUser(string query)
        {
            List<User> results = userService.SearchUser(query);

            if (results.Count == 0)
            {
                Console.WriteLine("No books found matching the query.");
            }
            else
            {
                Console.WriteLine("Search Results:");
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {results[i].Name} by {results[i].Email}");
                }
            }
            Console.WriteLine();
        }



        // Update
        public bool UpdateUserName(int userId, string newName)
        {
            return userService.UpdateUserName(userId, newName);
        }

        public bool UpdateUserEmail(int userId, string newEmail)
        {
            return userService.UpdateUserEmail(userId, newEmail);
        }

        public bool UpdateUserDetails(int userId, string newName, string newEmail)
        {
            return userService.UpdateUserDetails(userId, newName, newEmail);
        }



        // Remove
        public void RemoveUser()
        {
            userService.RemoveUser();
        }



        // List
        public void ListUsers()
        {
            userService.ListUsers();
        }

        public void ShowUserDetails()
        {
            userService.ShowUserDetails();
        }


        // Borrow methods
        public void BorrowBook(int userId, string title)
        {
            borrowService.BorrowBook(userId, title);
        }


        public void ReturnBook(int userId)
        {
            borrowService.ReturnBook(userId);
        }


        public void ListAllTransactions()
        {
            if (Transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }

            Console.WriteLine("List of Borrow Transactions:");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction.ToString());
                Console.WriteLine(new string('-', 40));
            }
        }


        public void ListBorrowedBooks(int userId)
        {
            borrowService.ListBorrowedBooks(userId);
        }

    }
}

