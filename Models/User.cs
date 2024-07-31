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



        public override string ToString()
        {
            return $"User: {Name}\nID: {UserID}\nEmail: {Email}";
        }
    }
}
