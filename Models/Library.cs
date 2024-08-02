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


        //Default
        public Library()
        {
            Books = new List<Book>();
            Users = new List<User>();
        }

        public Library(Book books)
        {
            Books = new List<Book>() { books };
            Users = new List<User>();
        }

        public Library(User users)
        {
            Books = new List<Book>();
            Users = new List<User>() { users };
        }

        public Library(List<Book> books, List<User> users)
        {
            Books = books;
            Users = users;
        }

        private readonly BookService bookService;
        private readonly UserService userService;


        //Book
        public void AddBook(Book book)
        {
            bookService.AddBook(book);
        }

        public void RemoveBook()
        {
            bookService.RemoveBook();
        }

        public void UpdateBook()
        {
            bookService.RemoveBook();
        }

        public void ListBooks()
        {
            bookService.ListBooks();
        }


        //User
        public void AddUser(User user)
        {
            userService.AddUser(user);
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
