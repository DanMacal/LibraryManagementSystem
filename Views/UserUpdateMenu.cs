using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Views
{
    public class UserUpdateMenu
    {
        public static void ShowUpdateUserMenu(Library library)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========================================================");
                Console.WriteLine("             Update User Details");
                Console.WriteLine("==========================================================");
                Console.WriteLine();

                Console.WriteLine("1. Update User Name");
                Console.WriteLine("2. Update User Email");
                Console.WriteLine("4. Update All Details");
                Console.WriteLine("0. Back to Main Menu");
                Console.WriteLine();
                Console.Write("Please select an option: ");
                string updateChoice = Console.ReadLine();

                switch (updateChoice)
                {
                    // Name
                    case "1":
                        Console.WriteLine();  
                        Console.WriteLine("Enter the UserID of the user to update:");
                        if (int.TryParse(Console.ReadLine(), out int userID))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter the new name:");
                            string newName = Console.ReadLine();
                            bool success = library.UpdateUserName(userID, newName);

                            if (success)
                            {
                                Console.WriteLine($"User's Name updated successfully to {newName}.");
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid UserID.");
                        }
                        break;
                    // Email
                    case "2":
                        Console.WriteLine("Enter the UserID of the user to update:");
                        if (int.TryParse(Console.ReadLine(), out userID))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter the new Email:");
                            string newEmail = Console.ReadLine();
                            bool success = library.UpdateUserEmail(userID, newEmail);

                            if (success)
                            {
                                Console.WriteLine($"User's Email updated successfully to {newEmail}.");
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid User ID.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter the UserID of the user to update:");
                        if (int.TryParse(Console.ReadLine(), out userID))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter the new name:");
                            string updatedName = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the new email:");
                            string updatedEmail = Console.ReadLine();

                            bool success = library.UpdateUserDetails(userID, updatedName, updatedEmail);

                            if (success)
                            {
                                Console.WriteLine("User's Details updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid User ID.");
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
