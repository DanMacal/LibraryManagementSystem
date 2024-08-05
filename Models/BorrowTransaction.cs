using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSysyem.Models
{
    class BorrowTransaction
    {
        public int Transactionid { get; set; }
        public int UserID { get; set; }
        public int ISBM { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public BorrowTransaction(int transactionid, int userid, int isbm, DateTime borrowdate, DateTime? returnDate)
        {
            Transactionid = transactionid;
            UserID = userid;
            ISBM = isbm;
            BorrowDate = borrowdate;
            ReturnDate = returnDate;
        }
        

        public void BorrowBook()
        {
            // Yo
        }

        public void ReturnBook()
        {
            // Yo
        }
    }
}
