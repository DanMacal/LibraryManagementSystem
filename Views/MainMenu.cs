using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Views
{
    public class MainMenu
    {
        public static void ShowMainMenu()
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
                Console.WriteLine("5.  Show Book Details");
                Console.WriteLine("6.  List All Books");
                Console.WriteLine();
                Console.WriteLine("7.  Add User");
                Console.WriteLine("8.  Remove User");
                Console.WriteLine("9.  Update User Details");
                Console.WriteLine("10. Search User");
                Console.WriteLine("11. Show User Details");
                Console.WriteLine("12. List All Users");
                Console.WriteLine();
                Console.WriteLine("13. Borrow Book");
                Console.WriteLine("14. Return Book");
                Console.WriteLine("15. List All Borrow Transactions");
                Console.WriteLine();
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Please select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Create - Book
                        library.CreateBook();
                        break;
                    case "2":
                        // Remove - Book
                        library.RemoveBook();
                        break;
                    case "3":
                        // Update - Book
                        BookUpdateMenu.ShowUpdateBookMenu(library);
                        break;
                    case "4":
                        // Search - Book
                        Console.Clear();
                        Console.WriteLine("Enter search query:");
                        string queryBook = Console.ReadLine();
                        library.SearchBook(queryBook);
                        break;
                    case "5":
                        // Details - Book
                        Console.Clear();
                        library.ShowBookDetails();
                        break;
                    case "6":
                        // List - Book
                        library.ListBooks();
                        break;
                    case "7":
                        // Create - User
                        library.CreateUser();
                        break;
                    case "8":
                        // Remove - User
                        library.RemoveUser();
                        break;
                    case "9":
                        // Update - User
                        BookUpdateMenu.ShowUpdateBookMenu(library);
                        break;
                    case "10":
                        // Search - User
                        Console.Clear();
                        Console.WriteLine("Enter search query:");
                        string queryUser = Console.ReadLine();
                        library.SearchUser(queryUser);
                        break;
                    case "11":
                        // Details - User
                        Console.Clear();
                        library.ShowUserDetails();
                        break;
                    case "12":
                        // List - User
                        library.ListUsers();
                        break;
                    case "13":
                        // Borrow - Book
                        break;
                    case "14":
                        // Return - Book
                        break;
                    case "15":
                        // List Transactions
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
