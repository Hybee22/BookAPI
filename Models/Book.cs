using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "ISBN must be between 3 and 10 characters")]
        public int Isbn { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Title cannot be more than 200 charcters")]

        public string Title { get; set; }

        public DateTime? DatePublished { get; set; }

        public virtual IEnumerable<Review> Reviews { get; set; }
        public virtual IEnumerable<BookAuthor> BookAuthors { get; set; }
        public virtual IEnumerable<BookCategory> BookCategories { get; set; }
    }
}
