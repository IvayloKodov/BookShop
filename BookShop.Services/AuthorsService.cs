using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BookShop.Data;
using BookShop.Data.Models;
using BookShop.Services.Models.Authors;
using BookShop.Services.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Services
{
    using Interfaces;

    public class AuthorsService : IAuthorsService
    {
        private readonly BookShopDbContext _dbContext;

        public AuthorsService(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AuthorDetailsServiceModel> DetailsAsync(int authorId)
        {
            return await _dbContext.Authors
                                   .Where(a => a.AuthorId == authorId)
                                   .ProjectTo<AuthorDetailsServiceModel>()
                                   .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BooksByAuthorServiceModel>> GetBooksAsync(int authorId)

            => await _dbContext.Books
                               .Where(b => b.AuthorId == authorId)
                               .ProjectTo<BooksByAuthorServiceModel>()
                               .ToListAsync();

        public async Task<int> CreateAsync(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();

            return author.AuthorId;
        }

        public async Task<bool> ExistsAsync(int authorId)
        {
            return await _dbContext.Authors.AnyAsync(a => a.AuthorId == authorId);
        }
    }
}
