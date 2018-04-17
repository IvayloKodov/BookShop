using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            builder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder.Entity<Book>()
                .HasMany(b => b.Categories)
                .WithOne(bc => bc.Book)
                .HasForeignKey(b => b.BookId);
             
            builder.Entity<Book>()
                .HasMany(b => b.Categories)
                .WithOne(bc => bc.Book)
                .HasForeignKey(b => b.BookId);

            builder.Entity<Category>()
                .HasMany(b => b.Books)
                .WithOne(bc => bc.Category)
                .HasForeignKey(b => b.CategoryId);

            builder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);

        }
    }
}
