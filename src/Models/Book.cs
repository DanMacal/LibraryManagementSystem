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
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public string ISBN { get; set; }    
        public bool IsAvailable { get; set; } = true;


        public Book(string title, string author, Genre genre, string isbn)
        {
            Title = title;
            Author = author;
            Genre = genre;
            ISBN = isbn;
        }


        public void UpdateTitle(string newTitle)
        {
            Title = newTitle;
        }


        public void UpdateAuthor(string newAuthor)
        {
            Author = newAuthor;
        }


        public void UpdateGenre(Genre newGenre)
        {
            Genre = newGenre;
        }


        public void UpdateBookDetails(string newAuthor, Genre? newGenre)
        {
            if (!string.IsNullOrEmpty(newAuthor))
            {
                UpdateAuthor(newAuthor);
            }

            if (newGenre.HasValue)
            {
                UpdateGenre(newGenre.Value);
            }
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
