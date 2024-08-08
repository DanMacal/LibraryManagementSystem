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
        public long ISBN { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }

        public Book(string title, long isbn, string author, Genre genre)
        {
            Title = title;
            ISBN = isbn;
            Author = author;
            Genre = genre;
        }


        public void UpdateTitle(string newTitle)
        {
            Title = newTitle;
            Console.WriteLine($"Book title has been updated to '{newTitle}'.");
        }


        public void UpdateAuthor(string newAuthor)
        {
            Author = newAuthor;
            Console.WriteLine($"Book author has been updated to '{newAuthor}'.");
        }


        public void UpdateGenre(Genre newGenre)
        {
            Genre = newGenre;
            Console.WriteLine($"Book genre has been updated to '{newGenre}'.");
        }


        public void UpdateDetails(string newAuthor, Genre? newGenre)
        {
            if (!string.IsNullOrEmpty(newAuthor))
            {
                UpdateAuthor(newAuthor);
            }

            if (newGenre.HasValue)
            {
                UpdateGenre(newGenre.Value);
            }

            Console.WriteLine($"Book '{Title}' details have been successfully updated.");
        }

        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nGenre: {Genre}\nISBN: {ISBN}";
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
