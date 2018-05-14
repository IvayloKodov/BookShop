using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Models;
using BookShop.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BookShop.Tests
{
    public class Tests
    {
        public Tests()
        {
            TestsInit.Initialize();
        }

        [Fact]
        public async Task BookDetailsShouldReturnCorrectBookId()
        {
            //Arrange 
            var db = this.GetDatabase();

            var bookId = 1;
            var price = 10m;

            var book = new Book()
            {
                BookId = bookId,
                Price = price,
                Title = "BD",
                Description = "Description",
                Author = new Author { FirstName = "John", LastName = "Moore" },
                Categories = new List<BookCategory> { new BookCategory { Category = new Category { Name = "Drama"} } }
            };

            db.Add(book);
            await db.SaveChangesAsync();

            var bookService = new BooksService(db);

            //Act
            var result = await bookService.BookDetailsAsync(bookId);

            //Assert
            Assert.NotNull(result);
            Assert.True(bookId == result.BookId);
            Assert.True(price == result.Price);
        }

        private BookShopDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<BookShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new BookShopDbContext(dbOptions);
        }
    }
}
