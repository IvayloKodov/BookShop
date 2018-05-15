using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Data.Models;
using BookShop.Services.Interfaces;
using BookShop.Services.Models.Books;
using Microsoft.Extensions.Caching.Memory;

namespace BookShop.Services.CacheServices
{
    public class CachedBooksService : ICachedBooksService
    {
        private readonly IMemoryCache _cache;
        private readonly IBooksService _booksService;

        private static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromSeconds(60);

        public CachedBooksService(IMemoryCache cache, IBooksService booksService)
        {
            _cache = cache;
            _booksService = booksService;
        }

        public async Task<BookDetailsServiceModel> BookDetailsAsync(int bookId)
        {
            var bookDetailsCacheKey = nameof(Book) + "/" + bookId;

            return await _cache.GetOrCreateAsync(bookDetailsCacheKey, async entry =>
            {
                entry.SlidingExpiration = DefaultCacheDuration;
                return await _booksService.BookDetailsAsync(bookId);
            });
        }

        public async Task<IEnumerable<BooksListServiceModel>> SearchAsync(string searchQuery)
        {
            var searchBooksCacheKey = nameof(Book) + "s/query=" + searchQuery;

            return await _cache.GetOrCreateAsync(searchBooksCacheKey, async entry =>
            {
                entry.SlidingExpiration = DefaultCacheDuration;
                return await _booksService.SearchAsync(searchQuery);
            });
        }

        public async Task<int> CreateAsync(int authorId, string title, string description, decimal price, int copies, int? edition,
            int? ageRestriction, DateTime releaseDate, string categories)
        {
            return await _booksService.CreateAsync(authorId, title, description, price, copies, edition, ageRestriction, releaseDate, categories);
        }
    }
}
