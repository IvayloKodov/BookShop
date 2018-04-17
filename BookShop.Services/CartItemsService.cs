using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Services.Interfaces;
using BookShop.Services.Models;
using BookShop.Services.Models.Shopping;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Services
{
    public class CartItemsService : ICartItemsService
    {
        private readonly BookShopDbContext _dbContext;

        public CartItemsService(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CartItemServiceModel>> GetCartsItemsServiceModelAsync(List<CartItem> items)
        {

            var itemIds = items.Select(i => i.BookId);

            var itemQuantities = items.ToDictionary(i => i.BookId, i => i.Quantity);

            var itemsWithDetails = await _dbContext
                .Books
                .Where(b => itemIds.Contains(b.BookId))
                .Select(b => new CartItemServiceModel
                {
                    BookId = b.BookId,
                    BookTitle = b.Title,
                    Price = b.Price,
                    Quantity = itemQuantities[b.BookId],
                    Total = b.Price * itemQuantities[b.BookId]
                })
                .ToListAsync();

            return itemsWithDetails;
        }
    }
}