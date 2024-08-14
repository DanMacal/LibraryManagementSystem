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

            Book ToKillaMockingBird = new Book("To Kill a Mockingbird", "Harper Lee", Genre.Novel, "978-0-06-112008-4");
            library.AddBook(ToKillaMockingBird);

            Book watchmen = new Book("Watchmen", "Alan Moore", Genre.Comics, "978-0-930289-23-1");
            library.AddBook(watchmen);

            Book theHobbit = new Book("The Hobbit", "J.R.R. Tolkien", Genre.Fantasy, "978-0-261-10333-3");
            library.AddBook(theHobbit);

            Book hitchhikersGuide = new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", Genre.Humor, "978-0-345-39180-3");
            library.AddBook(hitchhikersGuide);

            Book prideAndPrejudice = new Book("Pride and Prejudice", "Jane Austen", Genre.Romance, "978-1-85326-000-1");
            library.AddBook(prideAndPrejudice);

            Book dune = new Book("Dune", "Frank Herbert", Genre.ScienceFiction, "978-0-441-17271-9");
            library.AddBook(dune);

            Book nineStories = new Book("Nine Stories", "J.D. Salinger", Genre.ShortStory, "978-0-316-76950-3");
            library.AddBook(nineStories);


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
                        Console.Clear();
                        Console.WriteLine("Enter your User ID: ");
                        int userIdBorrow = Convert.ToInt32(Console.ReadLine());

                        library.ListBooks();
                        Console.WriteLine("\nType the book you want to borrow: ");
                        string titleBookBorrow = Console.ReadLine();
                        library.BorrowBook(userIdBorrow, titleBookBorrow);
                        break;
                    case "14":
                        // Return - Book
                        Console.Clear();
                        Console.WriteLine("Enter your User ID: ");
                        int userIdReturn = Convert.ToInt32(Console.ReadLine());
                        
                        library.ListBorrowedBooks(userIdReturn);

                        Console.WriteLine("Enter the book you want to return: ");
                        Console.WriteLine();
                        string titleBookReturn = Console.ReadLine();
                        library.ReturnBook(userIdReturn, titleBookReturn);
                        break;
                    case "15":
                        // List Transactions
                        Console.Clear();
                        library.ListAllTransactions();
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
