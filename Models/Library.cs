using LibraryManagementSysyem.Services;
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
        public List<BorrowTransaction> Transactions { get; set; } = new List<BorrowTransaction>();

        // Business Logic
        private readonly BookService bookService;
        private readonly UserService userService;

        public Library()
        {
            Books = new List<Book>();
            Users = new List<User>();
            bookService = new BookService(Books);
            userService = new UserService(Users);
        }

        public Library(Book book)
        {
            Books = new List<Book> { book };
            Users = new List<User>();
            bookService = new BookService(Books);
            userService = new UserService(Users);
        }

        public Library(User user)
        {
            Books = new List<Book>();
            Users = new List<User> { user };
            bookService = new BookService(Books);
            userService = new UserService(Users);
        }

        public Library(List<Book> books, List<User> users)
        {
            Books = books ?? new List<Book>();
            Users = users ?? new List<User>();
            bookService = new BookService(Books);
            userService = new UserService(Users);
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
    }
}
