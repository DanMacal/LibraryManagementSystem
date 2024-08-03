using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSysyem.Models
{
    class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(int userid, string name, string email)
        {
            UserID = userid;
            Name = name;
            Email = email;
        }

        public void UpdateUserDetails(string name, string email)
        {
            Name = name;
            Email = email;

            Console.WriteLine($"User's details with ID {UserID} has been successfully updated.");
        }


        public void UpdateUserName(string name)
        {
            Name = name;

            Console.WriteLine($"User's name with ID {UserID} has been successfully updated.");
        }
            

        public void UpdateUserEmail(string email)
        {
            Email = email;

            Console.WriteLine($"User's email with ID {UserID} has been successfully updated.");
        }


        public override string ToString()
        {
            return $"User: {Name}\nID: {UserID}\nEmail: {Email}";
        }
    }
}
