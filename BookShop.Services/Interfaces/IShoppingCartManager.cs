using System.Collections.Generic;
using BookShop.Services.Models.Shopping;

namespace BookShop.Services.Interfaces
{
    public interface IShoppingCartManager
    {
        void AddToShoppingCart(string shoppingCartId, int bookId);
        void RemoveFromShoppingCart(string shoppingCartId, int bookId);
        IEnumerable<CartItem> GetItems(string shoppingCartId);
    }
}