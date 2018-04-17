using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static BookShop.Data.DataConstants;

namespace BookShop.Data.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(AuthorFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorLastNameMaxLength)]
        public string LastName { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}