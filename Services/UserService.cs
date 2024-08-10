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


        // Add/Create 
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



        // Search
        public List<User> SearchUser(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Search query cannot be empty.");
                return new List<User>();
            }

            List<User> matchingUsers = Users.FindAll(u =>
                u.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                u.Email.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
            );

            return matchingUsers;
        }

     

        // Update
        public bool UpdateUserName(string oldName, string newName)
        {
            var user = Users.Find(u => u.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                user.UpdateUserName(newName);
                return true;
            }
            return false;
        }

        public bool UpdateUserEmail(string name, string newEmail)
        {
            var user = Users.Find(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                user.UpdateUserEmail(newEmail);
            }
            return false;
        }


        public bool UpdateUserDetails(string name, string newEmail)
        {
            var user = Users.Find(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                user.UpdateUserDetails(name, newEmail);
                return true;
            }
            return false;
        }



        // Remove
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



        // Details
        public void ShowUserDetails()
        {
            ListUsers();

            Console.WriteLine("Enter the number of the user to view details: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= Users.Count)
            {
                var selectedUser = Users[index - 1];
                Console.Clear();
                Console.WriteLine($"Name: {selectedUser.Name}");
                Console.WriteLine($"Email: {selectedUser.Email}");
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a valid user number.");
            }
        }



        // List
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
