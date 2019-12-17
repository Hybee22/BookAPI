using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Country Country { get; set; }

        public virtual IEnumerable<BookAuthor> BookAuthors { get; set; }
    }
}
