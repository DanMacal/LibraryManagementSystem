using LibraryManagementSysyem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSysyem.Models
{
    public interface IBorrowable
    {
        void BorrowBook();
        void ReturnBook();
    }
}
