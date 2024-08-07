using LibraryManagementSystem.Services;
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
            bookService = new BookService(Books);
            userService = new UserService(Users);
            borrowService = new BorrowService(this);
        }

        public Library(List<Book> books, List<User> users)
        {
            Books = books ?? new List<Book>();
            Users = users ?? new List<User>();
            Transactions = new List<BorrowTransaction>();
            bookService = new BookService(Books);
            userService = new UserService(Users);
            borrowService = new BorrowService(this);
        }


        // Book methods
        public void AddBook(Book book)
        {
            bookService.AddBook(book);
        }

        public Book SearchBook(string query)
        {
            return bookService.SearchBook(query);
        }

        public void UpdateBook(string title, Book updatedBook)
        {
            bookService.UpdateBook(title, updatedBook);
        }

        public void RemoveBook()
        {
            bookService.RemoveBook();
        }

        public void ListBooks()
        {
            bookService.ListBooks();
        }


        // User methods
        public void AddUser(User user)
        {
            userService.AddUser(user);
        }

        public User SearchUser(string query)
        {
            return userService.SearchUser(query);
        }

        public void UpdateUser(string name, User updatedUser)
        {
            userService.UpdateUser(name, updatedUser);
        }

        public void RemoveUser()
        {
            userService.RemoveUser();
        }

        public void ListUsers()
        {
            userService.ListUsers();
        }


        // Borrow methods
        public void BorrowBook(int userId, string title)
        {
            borrowService.BorrowBook(userId, title);
        }

        public void ReturnBook(int userId, string title)
        {
            borrowService.ReturnBook(userId, title);
        }
    }
}

