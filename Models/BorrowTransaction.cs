using LibraryManagementSysyem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryManagementSysyem.Models
{
    class BorrowTransaction : IBorrowable
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public Book BorrowedBook { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public BorrowTransaction() { }

        public BorrowTransaction(int transactionid, int userid, Book borrowedBook, DateTime borrowDate, DateTime? returnDate = null)
        {
            TransactionID = transactionid;
            UserID = userid;
            BorrowedBook = borrowedBook;
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
        }


        public void BorrowBook()
        {
            BorrowDate = DateTime.Now;
            Console.WriteLine($"{BorrowedBook.Title} borrowed by User {UserID} on {BorrowDate}");
        }


        public void ReturnBook()
        { 
            ReturnDate = DateTime.Now;
            Console.WriteLine($"{BorrowedBook.Title} returned by User {UserID} on {ReturnDate}");
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
