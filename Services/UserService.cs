using LibraryManagementSysyem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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
                Console.WriteLine($"'{user.Name}' has been successfully added.");
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

        public void UpdateUser(int userId, User updatedUser)
        {
            var user = Users.Find(u => u.UserID == userId);

            if (user != null)
            {
                user.Name = updatedUser.Name;

                Console.WriteLine($"User with ID {userId} has been successfully updated.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void ListUsers()
        {
            Console.WriteLine("Users in Library:");

            if (Users.Count == 0)
            {
                Console.WriteLine("No users to display.");
            }
            else
            {
                Users.ForEach(user => Console.WriteLine(user.Name));
            }
        }

        private bool IsValidUser(User user)
        {
            return user != null && !string.IsNullOrEmpty(user.Name) && user.UserID > 0 && !string.IsNullOrEmpty(user.Email);
        }
    }
}
