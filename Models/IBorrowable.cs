using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSysyem.Models
{
    interface IBorrowable
    {
        public void BorrowBook();
        public void ReturnBook();
    }
}
