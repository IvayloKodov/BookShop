using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BookShop.Data;
using BookShop.Data.Models;
using BookShop.Services.Interfaces;
using BookShop.Services.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Services
{
    public class BooksService : IBooksService
    {
        private readonly BookShopDbContext _dbContext;

        public BooksService(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookDetailsServiceModel> BookDetails(int bookId)
        {
            return await _dbContext.Books
                .Where(b => b.BookId == bookId)
                .ProjectTo<BookDetailsServiceModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BooksListServiceModel>> Search(string searchQuery)
        {
            return await _dbContext.Books
                .Where(b => b.Title.ToLower().Contains(searchQuery.ToLower()))
                .OrderBy(b => b.Title)
                .Take(10)
                .ProjectTo<BooksListServiceModel>()
                .ToListAsync();
        }

        public async Task<int> Create(int authorId, string title, string description, decimal price, int copies, int? edition, int? ageRestriction, DateTime releaseDate, string categories)
        {
            var categoryNames = categories.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var existingCategories = await _dbContext
                .Categories
                .Where(c => categoryNames.Contains(c.Name))
                .ToListAsync();

            var allCategories = new List<Category>(existingCategories);

            foreach (var categoryName in categoryNames)
            {
                if (existingCategories.All(c => c.Name != categoryName))
                {
                    var category = new Category
                    {
                        Name = categoryName
                    };

                    this._dbContext.Add(category);

                    allCategories.Add(category);
                }
            }

            await this._dbContext.SaveChangesAsync();

            var book = new Book
            {
                AuthorId = authorId,
                Title = title,
                Description = description,
                Price = price,
                Copies = copies,
                Edition = edition,
                AgeRestriction = ageRestriction,
                ReleaseDate = releaseDate
            };

            allCategories.ForEach(c => book.Categories.Add(new BookCategory
            {
                CategoryId = c.CategoryId
            }));

            _dbContext.Books.Add(book);

            await _dbContext.SaveChangesAsync();

            return book.BookId;
        }
    }
}