using BookShop.Common.Mapping;
using BookShop.Data.Models;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace BookShop.Services.Models.Authors
{
    public class AuthorDetailsServiceModel : IMapFrom<Author>, IHaveCustomMappings
    {
        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> BookTitles { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Author, AuthorDetailsServiceModel>()
                     .ForMember(a => a.BookTitles, cfg => cfg.MapFrom(x => x.Books.Select(b => b.Title)));
    }
}
