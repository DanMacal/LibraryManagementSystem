using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public string Title { get; set; }
        public int ISBN { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }

        public Book(string title, int isbn, string author, Genre genre)
        {
            Title = title;
            ISBN = isbn;
            Author = author;
            Genre = genre;
        }


        public void UpdateBookDetails(string author, Genre genre)
        {
            Author = author;
            Genre = genre;

            Console.WriteLine($"Book '{Title}' details has been successfully updated.");
        }


        public void UpdateBookAuthor(string author)
        {
            Author = author;

            Console.WriteLine($"Book '{Title}' author has been successfully updated.");
        }


        public void UpdateBookGenre(Genre genre)
        {
            Genre = genre;

            Console.WriteLine($"Book '{Title}' genre has been successfully updated.");
        }


        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nGenre: {Genre}\nISBM: {ISBN}";
        }
    }

    public enum Genre
    {
        Novel = 1, 
        Comics,
        Fantasy,
        Humor,
        Romance,
        ScienceFiction,
        ShortStory
    }
}
