using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        public int Isbn { get; set; }

        public string Title { get; set; }

        public DateTime DatePublished { get; set; }

        public virtual IEnumerable<Review> Reviews { get; set; }
        public virtual IEnumerable<BookCategory> BookCategories { get; set; }
        public virtual IEnumerable<BookAuthor> BookAuthors { get; set; }
    }
}
