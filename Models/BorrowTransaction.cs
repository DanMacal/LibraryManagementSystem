using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryManagementSysyem.Models
{
    class BorrowTransaction
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public Book BorrowedBook { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public BorrowTransaction(int transactionid, int userid, Book borrowedbook, DateTime borrowdate, DateTime? returnDate)
        {
            TransactionID = transactionid;
            UserID = userid;
            BorrowedBook = borrowedbook;
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


        public override string ToString()
        {
            return $"Transaction ID: {TransactionID}\n" +
                   $"User ID: {UserID}\n" +
                   $"Book Title: {BorrowedBook.Title}\n" +
                   $"Borrow Date: {BorrowDate}\n" +
                   $"Return Date: {(ReturnDate.HasValue ? ReturnDate.Value.ToString() : "Not Returned Yet")}";
        }
    }
}
