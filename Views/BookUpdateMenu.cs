using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        {
                            Console.WriteLine("Book title updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                        break;
                    // Author
                    case "2":
                        Console.WriteLine("Enter the new author:");
                        string newAuthor = Console.ReadLine();
                        library.UpdateBookAuthor(title, newAuthor);

                        if (success)
                        {
                            Console.WriteLine("Book's author updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid author.");
                        }
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
                            {
                                Console.WriteLine("Book genre updated successfully.");
                            }
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
                        {
                            Console.WriteLine("Book details updated successfully.");
                        }
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
    }
}
