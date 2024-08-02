using LibraryManagementSysyem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSysyem.Services
{
    class UserService
    {
        private readonly List<User> Users;

        public UserService(List<User> users)
        {
            Users = users;
        }

        public void AddUser(User user)
        {
            if (IsValidUser(user))
            {
                Users.Add(user);
                Console.WriteLine($"{user} has been successfully added.");
            }
            else
            {
                Console.WriteLine("Please enter a valid user.");
            }
        }

        public void RemoveUser()
        {
            ListUsers();

            if (Users.Count == 0) return;

            Console.WriteLine("\nEnter the number of the user to remove:");
            if (int.TryParse(Console.ReadLine(), out int removeIndex) &&
            removeIndex > 0 &&
                removeIndex <= Users.Count)
            {
                Console.WriteLine();
                Console.WriteLine($"User '{Users[removeIndex - 1]}' removed successfully.");
                Users.RemoveAt(removeIndex - 1);
            }
            else
            {
                Console.WriteLine("Please enter a valid user number.");
            }
        }

        public void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("Users in Library:");

            if (Users.Count == 0)
            {
                Console.WriteLine("No users to display.");
            }
            else
            {
                for (int i = 0; i < Users.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Users[i]}");
                }
            }
        }

        private bool IsValidUser(User user)
        {
            return user != null && !string.IsNullOrEmpty(user.Name) && user.UserID > 0 && !string.IsNullOrEmpty(user.Email);
        }
    }
}
