using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Services
{
    public class UserService
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


        public void CreateUser()
        {
            Console.Clear();

            Console.WriteLine("\nEnter UserID: ");
            int userid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("\nEnter Email: ");
            string email = Console.ReadLine();

            User newUser = new User(userid, name, email);

            AddUser(newUser);
        }


        public User SearchUser(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            return Users.Find(u =>
                u.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                u.Email.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
            );
        }


        public void UpdateUser(string name, User updatedUser)
        {
            var user = Users.Find(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;

                Console.WriteLine($"User with name '{name}' has been successfully updated.");
            }
            else
            {
                Console.WriteLine("User not found.");
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
            Console.WriteLine();
            if (Users.Count == 0)
            {
                Console.WriteLine("No users to display.");
            }

            for (int i = 0; i < Users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Users[i].Name}");
            }
        }


        private bool IsValidUser(User user)
        {
            return user != null && !string.IsNullOrEmpty(user.Name) && user.UserID > 0 && !string.IsNullOrEmpty(user.Email);
        }
    }
}
