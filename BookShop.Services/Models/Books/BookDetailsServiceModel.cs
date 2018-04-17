using System.Linq;
using AutoMapper;
using BookShop.Data.Models;

namespace BookShop.Services.Models.Books
{
    public class BookDetailsServiceModel : BooksByAuthorServiceModel
    {
        public string AuthorName { get; set; }

        public override void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Book, BookDetailsServiceModel>()
                .ForMember(m => m.AuthorName, cfg => cfg.MapFrom(b => b.Author.FirstName + " " + b.Author.LastName))
                .ForMember(m => m.Categories, cfg => cfg.MapFrom(b => b.Categories.Select(c => c.Category.Name)));
        }
    }
}
