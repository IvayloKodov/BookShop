using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using BookShop.Common.Mapping;
using BookShop.Data.Models;

using static BookShop.Data.DataConstants;

namespace BookShop.Services.Models.Books
{
    public class BooksByAuthorServiceModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int BookId { get; set; }

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

        public IEnumerable<string> Categories { get; set; }

        public virtual void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Book, BooksByAuthorServiceModel>()
                  .ForMember(bm => bm.Categories, cfg => cfg.MapFrom(b => b.Categories.Select(c => c.Category.Name)));
        }
    }
}
