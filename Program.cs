using LibraryManagementSysyem.Models;
using System;

namespace ManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();

            var GOT1 = new Book("A Game of Thrones", 0_553_10354_7, "George R. R. Martin", Genre.Fantasy);
            library.AddBook(GOT1);
            var GOT2 = new Book("A Clash of Kings",  0_553_10803_4, "George R. R. Martin",Genre.Fantasy);
            library.AddBook(GOT2);
            Console.WriteLine();

            library.ListBooks();
            Console.WriteLine();

            var daniel = new User(432, "Daniel", "dan.dan@hotmail.com");
            library.AddUser(daniel);
            var tanner = new User(451, "Tanner", "tanner.tanner@outlook.com");
            library.AddUser(tanner);
            Console.WriteLine();

            library.ListUsers();
            Console.WriteLine();

            daniel.UpdateUserDetails("Danny", "dan.dan");
            Console.WriteLine(daniel);
            Console.WriteLine();

            library.UpdateUser("Danny", daniel);
            library.ListUsers();
            Console.WriteLine();

            BorrowTransaction book1 = new BorrowTransaction(213, 133, GOT1,DateTime.Now, DateTime.Now);
            Console.WriteLine(book1);

            book1.BorrowBook();

            Console.ReadKey();
        }
    }
}