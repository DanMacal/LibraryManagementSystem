using LibraryManagementSysyem.Models;
using System;

namespace ManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            User daniel = new User (423, "Daniel", "daniel.mca@gmai.com");
            Console.WriteLine(daniel);
            Console.WriteLine();

            User tanner = new User(423, "Tanner", "tanner.asa@gmai.com");
            Console.WriteLine(daniel);
            Console.WriteLine();

            Book GOT1 = new Book("A Clash of Kings", 12313, "George R. R. Martin", Genre.Science_Fiction);
            Console.WriteLine(GOT1);

            Book GOT2 = new Book("A Storm of Swords", 45433, "George R. R. Martin", Genre.Science_Fiction);

            List<Book> books = new List<Book>() { GOT1, GOT2 };

            List<User> users = new List<User>() {daniel, tanner };

            Console.ReadKey();
        }
    }
}