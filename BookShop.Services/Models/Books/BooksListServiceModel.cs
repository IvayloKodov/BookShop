using BookShop.Common.Mapping;
using BookShop.Data.Models;

namespace BookShop.Services.Models.Books
{
    public class BooksListServiceModel : IMapFrom<Book>
    {
        public int BookId { get; set; }

        public string Title { get; set; }
    }
}
