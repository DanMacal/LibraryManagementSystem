using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSysyem.Models
{
    class Book
    {
        public string Title { get; set; }
        public int ISBN { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }

        public Book(string title, int isbm, string author, Genre genre)
        {
            Title = title;
            ISBN = isbm;
            Author = author;
            Genre = genre;
        }


        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nGenre: {Genre}\nISBM: {ISBN}";
        }
    }

    public enum Genre
    {
        Novel,
        Comics,
        Fantasy,
        Humor,
        Romance,
        Science_Fiction,
        Short_Story
    }
}
