using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static BookShop.Data.DataConstants;

namespace BookShop.Data.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int? AgeRestriction { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int Copies { get; set; }

        public decimal Price { get; set; }

        public int? Edition { get; set; }

        public int AuthorId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Author Author { get; set; }

        public List<BookCategory> Categories { get; set; } = new List<BookCategory>();
    }
}
