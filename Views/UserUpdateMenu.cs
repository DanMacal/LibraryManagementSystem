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
                Console.WriteLine("Enter the title of the user to update:");
                string name = Console.ReadLine();

                Console.WriteLine("1. Update User Name");
                Console.WriteLine("2. Update User Email");
                Console.WriteLine("4. Update All Details");
                Console.WriteLine("0. Back to Main Menu");
                Console.WriteLine();
                Console.Write("Please select an option: ");
                string updateChoice = Console.ReadLine();
                bool success = false;

                switch (updateChoice)
                {
                    // Name
                    case "1":
                        Console.WriteLine("Enter the new name:");
                        string newName = Console.ReadLine();
                        success = library.UpdateUserName(name, newName);

                        if (success)
                        {
                            Console.WriteLine("User's Name updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                        break;
                    // Email
                    case "2":
                        Console.WriteLine("Enter the new Email:");
                        string newEmail = Console.ReadLine();
                        success = library.UpdateUserName(name, newEmail);

                        if (success)
                        {
                            Console.WriteLine("User's Email updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter the new name:");
                        string updatedName = Console.ReadLine();

                        Console.WriteLine("Enter the new email:");
                        string updatedEmail = Console.ReadLine();

                        success = library.UpdateUserDetails(updatedName, updatedEmail);

                        if (success)
                        {
                            Console.WriteLine("User's Details updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
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
