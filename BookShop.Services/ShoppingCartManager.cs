using System.Collections.Concurrent;
using System.Collections.Generic; 
using BookShop.Services.Interfaces; 
using BookShop.Services.Models.Shopping;

namespace BookShop.Services
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly ConcurrentDictionary<string, ShoppingCart> _shoppingCarts;

        public ShoppingCartManager()
        {
            _shoppingCarts = new ConcurrentDictionary<string, ShoppingCart>();
        }

        public void AddToShoppingCart(string shoppingCartId, int bookId)
        {
            var shoppingCart = GetShoppingCart(shoppingCartId);

            shoppingCart.AddToCart(bookId);
        }

        public void RemoveFromShoppingCart(string shoppingCartId, int bookId)
        {
            var shoppingCart = GetShoppingCart(shoppingCartId);

            shoppingCart.RemoveFromCart(bookId);
        }

        public IEnumerable<CartItem> GetItems(string shoppingCartId)
            => GetShoppingCart(shoppingCartId).Items;

        private ShoppingCart GetShoppingCart(string shoppingCartId)
            => _shoppingCarts.GetOrAdd(shoppingCartId, new ShoppingCart());
    }
}
