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

            var existingTransaction = Library.Transactions
            .FirstOrDefault(t => t.UserID == t.UserID && 
            t.BorrowedBook.Title.Equals(title, StringComparison.OrdinalIgnoreCase) 
            && !t.ReturnDate.HasValue);

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


        public void ReturnBook(int userId)
        {
            var user = Library.Users.FirstOrDefault(u => u.UserID == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            if (user.BorrowedBooks.Count == 0)
            {
                Console.WriteLine("No books borrowed by the user.");
                return;
            }

            ListBorrowedBooks(userId);

            Console.WriteLine("\nEnter the number of the book you want to return:");
            if (int.TryParse(Console.ReadLine(), out int bookIndex) &&
                bookIndex > 0 &&
                bookIndex <= user.BorrowedBooks.Count)
            {
                var transaction = user.BorrowedBooks[bookIndex - 1];

                if (transaction != null && !transaction.ReturnDate.HasValue)
                {
                    transaction.ReturnDate = DateTime.Now;
                    Console.WriteLine($"Book '{transaction.BorrowedBook.Title}' returned successfully.");
                }
                else
                {
                    Console.WriteLine("Book has already been returned or transaction not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a valid book number.");
            }
        }
        
        public void ListBorrowedBooks(int userId)
        {
            var user = Library.Users.FirstOrDefault(u => u.UserID == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            var borrowedBooks = user.BorrowedBooks.Where(t => !t.ReturnDate.HasValue).ToList();

            Console.WriteLine();
            Console.WriteLine("Books borrowed by the user:");
            for (int i = 0; i < borrowedBooks.Count; i++)
            {
                var book = borrowedBooks[i];
                Console.WriteLine($"{i + 1}. {book.BorrowedBook.Title} by {book.BorrowedBook.Author}");
            }

        }


        private int GenerateTransactionID()
        {
            return Library.Transactions.Count + 1;
        }
    }
}
