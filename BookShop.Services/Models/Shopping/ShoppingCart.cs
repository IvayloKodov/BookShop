using System.Collections.Generic;
using System.Linq;
using BookShop.Data;

namespace BookShop.Services.Models.Shopping
{
    public class ShoppingCart
    {
        private readonly BookShopDbContext _dbContext;
        private readonly IList<CartItem> _items;

        public ShoppingCart(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ShoppingCart()
        {
            _items = new List<CartItem>();
        }

        public void AddToCart(int bookId)
        {
            var itemExists = _dbContext.Books.Any(b => b.BookId == bookId);

            if (!itemExists)
            {
                return;
            }

            var cartItem = _items.FirstOrDefault(i => i.BookId == bookId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    BookId = bookId,
                    Quantity = 1
                };

                _items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
        }

        public void RemoveFromCart(int bookId)
        {
            var cartItem = _items.FirstOrDefault(i => i.BookId == bookId);

            if (cartItem != null)
            {
                _items.Remove(cartItem);
            }
        }

        public IEnumerable<CartItem> Items => new List<CartItem>(_items);
    }
}