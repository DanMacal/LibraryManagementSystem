﻿using LibraryManagementSysyem.Models;
using System;

namespace ManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();

            library.AddBook(new Book("A Game of Thrones", 0_553_10354_7, "George R. R. Martin", Genre.Fantasy));
            library.AddBook(new Book("A Clash of Kings",  0_553_10803_4, "George R. R. Martin",Genre.Fantasy));
            Console.WriteLine();
            library.ListBooks();
            Console.WriteLine();

            library.AddUser(new User(432, "Daniel", "dan.dan@hotmail.com"));
            library.AddUser(new User(451, "Tanner", "tanner.tanner@outlook.com"));
            Console.WriteLine();
            library.ListUsers();

            Console.ReadKey();
        }
    }
}