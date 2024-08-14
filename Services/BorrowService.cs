using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class BorrowService 
    {
        private readonly Library Library;

        public BorrowService(Library library)
        {
            Library = library;
        }


        public void BorrowBook(int userId, string title)
        {
            var user = Library.Users.FirstOrDefault(u => u.UserID == userId);
            var book = Library.Books.FirstOrDefault(b => b.Title == title);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            var transaction = new BorrowTransaction
            {
                TransactionID = GenerateTransactionID(),
                UserID = userId,
                BorrowedBook = book,
                BorrowDate = DateTime.Now,
                ReturnDate = null
            };

            user.BorrowedBooks.Add(transaction);
            Library.Transactions.Add(transaction);

            Console.WriteLine("Book borrowed successfully.");
        }


        public void ReturnBook(int userId, string title)
        {
            var user = Library.Users.FirstOrDefault(u => u.UserID == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            var transaction = user.BorrowedBooks
                .FirstOrDefault(t => t.BorrowedBook.Title == title && !t.ReturnDate.HasValue);

            if (transaction == null)
            {
                Console.WriteLine("Borrow transaction not found or book already returned.");
                return;
            }

            transaction.ReturnDate = DateTime.Now;

            Console.WriteLine("Book returned successfully.");
        }

        
        public void ListBorrowedBooks(int userId)
        {
            var borrowedBooks = Library.Transactions
                .Where(t => t.UserID == userId && !t.ReturnDate.HasValue)
                .Select(t => t.BorrowedBook)
                .ToList();

            if (borrowedBooks.Count == 0)
            {
                Console.WriteLine($"User {userId} has no borrowed books.");
                return;
            }

            Console.WriteLine($"User {userId} currently has the following borrowed books:");
            foreach (var book in borrowedBooks)
            {
                Console.WriteLine($"- {book.Title} by {book.Author}");
            }
        }


        private int GenerateTransactionID()
        {
            return Library.Transactions.Count + 1;
        }
    }
}
