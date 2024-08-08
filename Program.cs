using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            BorrowService borrowService = new BorrowService(library);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========================================================");
                Console.WriteLine("          Personal Library Management System");
                Console.WriteLine("==========================================================");
                Console.WriteLine();
                Console.WriteLine("1.  Add Book");
                Console.WriteLine("2.  Remove Book");
                Console.WriteLine("3.  Update Book Details");
                Console.WriteLine("4.  Search Book");
                Console.WriteLine("5.  List All Books");
                Console.WriteLine();
                Console.WriteLine("6.  Add User");
                Console.WriteLine("7.  Remove User");
                Console.WriteLine("8.  Update User Details");
                Console.WriteLine("9.  Search User");
                Console.WriteLine("10. List All Users");
                Console.WriteLine();
                Console.WriteLine("11. Borrow Book");
                Console.WriteLine("12. Return Book");
                Console.WriteLine("13. List All Borrow Transactions");
                Console.WriteLine();
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.CreateBook();
                        break;
                    case "2":
                        library.RemoveBook();
                        break;
                    case "3":
                        // Code to update book details
                        break;
                    case "4":
                        // Code to search book
                        break;
                    case "5":
                        library.ListBooks();
                        break;
                    case "6":
                        // Code to add user
                        break;
                    case "7":
                        // Code to remove user
                        break;
                    case "8":
                        // Code to update user details
                        break;
                    case "9":
                        // Code to search user
                        break;
                    case "10":
                        // Code to list all users
                        break;
                    case "11":
                        // Code to borrow book
                        break;
                    case "12":
                        // Code to return book
                        break;
                    case "13":
                        // Code to list all borrow transactions
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }


            



        }
    }
}
