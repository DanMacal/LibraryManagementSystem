using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<BorrowTransaction> BorrowedBooks { get; set; } = new List<BorrowTransaction>();

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
        }


        public void UpdateUserName(string name)
        {
            Name = name;
        }
            

        public void UpdateUserEmail(string email)
        {
            Email = email;
        }


        public override string ToString()
        {
            return $"User: {Name}\nID: {UserID}\nEmail: {Email}";
        }
    }
}
