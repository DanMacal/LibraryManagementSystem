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
                        string query = Console.ReadLine();
                        library.SearchBook(query);
                        break;
                    case "5":
                        // Details - Book
                        Console.Clear();
                        Console.Write("Enter the title of the book to view details: ");
                        string bookTitle = Console.ReadLine();
                        library.ShowBookDetails(bookTitle);
                        break;
                    case "6":
                        // List - Book
                        library.ListBooks();
                        break;
                    case "7":
                        // Create - User
                        library.RemoveUser();
                        break;
                    case "8":
                        // Remove - User
                        break;
                    case "9":
                        // Update - User
                        break;
                    case "10":
                        // Search - User
                        library.ListUsers();
                        break;
                    case "11":
                        // Details - User
                        break;
                    case "12":
                        // List - User
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
