using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Services.Models.Books;

namespace BookShop.Services.Interfaces
{
    public interface IBooksService
    {
        Task<BookDetailsServiceModel> BookDetails(int bookId);

        Task<IEnumerable<BooksListServiceModel>> Search(string searchQuery);

        Task<int> Create(int authorId, string title, string description, decimal price, int copies, int? edition, int? ageRestriction, DateTime releaseDate, string categories);
    }
}