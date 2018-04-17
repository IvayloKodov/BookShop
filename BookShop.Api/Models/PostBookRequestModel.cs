using System;
using System.ComponentModel.DataAnnotations;

using static BookShop.Data.DataConstants;

namespace BookShop.Api.Models
{
    public class PostBookRequestModel
    {
        [Required]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int? AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Copies { get; set; }

        public decimal Price { get; set; }

        public int? Edition { get; set; }

        public int AuthorId { get; set; }

        public string Categories { get; set; }
    }
}