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

            Book book1 = new Book("To Kill a Mockingbird", 9780060935467, "Harper Lee", Genre.Novel);
            Book book2 = new Book("1984", 9780451524935, "George Orwell", Genre.ScienceFiction);

            library.Books.Add(book1);
            library.Books.Add(book2);

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
                        ShowUpdateBookMenu(library);
                        break;
                    case "4":
                        // Code to search book
                        Console.Clear();
                        Console.WriteLine("Enter search query:");
                        string query = Console.ReadLine();
                        library.SearchBook(query);
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


            static void ShowUpdateBookMenu(Library library)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("             Update Book Details");
                    Console.WriteLine("==========================================================");
                    Console.WriteLine();
                    Console.WriteLine("Enter the title of the book to update:");
                    string title = Console.ReadLine();

                    Console.WriteLine("1. Update Book Title");
                    Console.WriteLine("2. Update Book Author");
                    Console.WriteLine("3. Update Book Genre");
                    Console.WriteLine("4. Update All Details");
                    Console.WriteLine("0. Back to Main Menu");
                    Console.WriteLine();
                    Console.Write("Please select an option: ");
                    string updateChoice = Console.ReadLine();
                    bool success = false;

                    switch (updateChoice)
                    {
                        // Title
                        case "1":
                            Console.WriteLine("Enter the new title:");
                            string newTitle = Console.ReadLine();
                            success = library.UpdateBookTitle(title, newTitle);

                            if (success)
                                Console.WriteLine("Book title updated successfully.");
                            else
                                Console.WriteLine("Book not found.");
                            break;
                        // Author
                        case "2":
                            Console.WriteLine("Enter the new author:");
                            string newAuthor = Console.ReadLine();
                            library.UpdateBookAuthor(title, newAuthor);
                            break;
                        // Genre
                        case "3":
                            Console.WriteLine("Select the new genre:");

                            foreach (var genre in Enum.GetValues(typeof(Genre)))
                            {
                                Console.WriteLine($"{(int)genre}. {genre}");
                            }

                            if (int.TryParse(Console.ReadLine(), out int genreInput) && Enum.IsDefined(typeof(Genre), genreInput))
                            {
                                Genre newGenre = (Genre)genreInput;
                                success = library.UpdateBookGenre(title, newGenre);
                                if (success)
                                    Console.WriteLine("Book genre updated successfully.");
                                else
                                    Console.WriteLine("Book not found.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid genre selection.");
                            }
                            break;
                        // All
                        case "4":
                            Console.WriteLine("Enter the new author (leave empty if no change):");
                            string updatedAuthor = Console.ReadLine();
                            Console.WriteLine("Select the new genre (or enter 0 for no change):");

                            foreach (var genre in Enum.GetValues(typeof(Genre)))
                            {
                                Console.WriteLine($"{(int)genre}. {genre}");
                            }
                            Genre? updatedGenre = null;

                            if (int.TryParse(Console.ReadLine(), out int genreInputForAll) && Enum.IsDefined(typeof(Genre), genreInputForAll))
                            {
                                updatedGenre = (Genre)genreInputForAll;
                            }
                            success = library.UpdateBookDetails(title, updatedAuthor, updatedGenre);

                            if (success)
                                Console.WriteLine("Book details updated successfully.");
                            else
                                Console.WriteLine("Book not found.");
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }


            //End
        }
    }
}
