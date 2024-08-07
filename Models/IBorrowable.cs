using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public interface IBorrowable
    {
        void BorrowBook();
        void ReturnBook();
    }
}
