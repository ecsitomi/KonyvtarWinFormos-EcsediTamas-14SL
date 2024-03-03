using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarWinFormos_EcsediTamas_14SL
{
    internal class Book
    {
        string author;
        int id;
        int page_count;
        int published_year;
        string title;

        public string Author { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Published_year { get; set; }
        public int Page_count { get; set; }

        public Book(string author, int id, int page_count, int published_year, string title)
        {
            Author = author;
            Id = id;
            Page_count = page_count;
            Published_year = published_year;
            Title = title;
        }
    }
}
