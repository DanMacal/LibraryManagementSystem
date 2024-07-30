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

            Console.ReadKey();
        }
    }
}