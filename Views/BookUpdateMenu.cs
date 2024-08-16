using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryManagementSystem.Views
{
    public class BookUpdateMenu
    {
        public static void ShowUpdateBookMenu(Library library)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========================================================");
                Console.WriteLine("             Update Book Details");
                Console.WriteLine("==========================================================");
                Console.WriteLine();
                Console.WriteLine("1. Update Book Title");
                Console.WriteLine("2. Update Book Author");
                Console.WriteLine("3. Update Book Genre");
                Console.WriteLine("4. Update All Details");
                Console.WriteLine("0. Back to Main Menu");
                Console.WriteLine();
                Console.Write("Please select an option: ");
                string updateChoice = Console.ReadLine();

                switch (updateChoice)
                {
                    case "1":
                        // Title
                        Console.WriteLine();
                        Console.WriteLine("Enter the Title of the book to update:");
                        string title = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Enter the new Title:");
                        string newTitle = Console.ReadLine();
                        bool titleUpdated = library.UpdateBookTitle(title, newTitle);

                        if (titleUpdated)
                        {
                            Console.WriteLine($"Book title has been updated to '{newTitle}'.");
                        }
                        else
                        {
                            Console.WriteLine("Book not found or update failed.");
                        }
                        break;  
                    case "2":
                        // Author
                        Console.WriteLine("Enter the Title of the book to update:");
                        string titleAuthor = Console.ReadLine();
                        Console.WriteLine("Enter the new Author:");
                        string newAuthor = Console.ReadLine();
                        bool authorUpdated = library.UpdateBookAuthor(titleAuthor, newAuthor);

                        if (authorUpdated)
                        {
                            Console.WriteLine($"Book author has been updated to '{newAuthor}'.");
                        }
                        else
                        {
                            Console.WriteLine("Book not found or update failed.");
                        }
                        break;
                    case "3":
                        // Genre
                        Console.WriteLine("Enter the Title of the book to update:");
                        string titleGenre = Console.ReadLine();

                        Console.WriteLine("\nSelect New Genre:");
                        foreach (var genre in Enum.GetValues(typeof(Genre)))
                        {
                            Console.WriteLine($"{(int)genre}. {genre}");
                        }

                        Genre newGenre;
                        while (true)
                        {
                            Console.WriteLine("\nEnter the number corresponding to the genre:");
                            if (int.TryParse(Console.ReadLine(), out int genreInput) && Enum.IsDefined(typeof(Genre), genreInput))
                            {
                                newGenre = (Genre)genreInput;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please try again.");
                            }
                        }

                        bool genreUpdated = library.UpdateBookGenre(titleGenre, newGenre);
                        if (genreUpdated)
                        {
                            Console.WriteLine($"Book genre has been updated to '{newGenre}'.");
                        }
                        else
                        {
                            Console.WriteLine("Book not found or update failed.");
                        }
                        break;
                    case "4":
                        // All3
                        Console.WriteLine("Enter the Title of the book to update:");
                        string titleUpdatedAll = Console.ReadLine();

                        Console.WriteLine("Enter the new Author:");
                        string authorUpdatedAll = Console.ReadLine();

                        Console.WriteLine("\nSelect New Genre:");
                        foreach (var genre in Enum.GetValues(typeof(Genre)))
                        {
                            Console.WriteLine($"{(int)genre}. {genre}");
                        }

                        Genre newGenreAll;
                        while (true)
                        {
                            Console.WriteLine("\nEnter the number corresponding to the genre:");
                            if (int.TryParse(Console.ReadLine(), out int genreInput) && Enum.IsDefined(typeof(Genre), genreInput))
                            {
                                newGenreAll = (Genre)genreInput;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please try again.");
                            }
                        }

                        bool detailsUpdated = library.UpdateBookDetails(titleUpdatedAll, authorUpdatedAll, newGenreAll);

                        if (detailsUpdated)
                        {
                            Console.WriteLine($"Book '{titleUpdatedAll}' details have been successfully updated.");
                        }
                        else
                        {
                            Console.WriteLine("Book not found or update failed.");
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
            }
        }
    }
}
