using System;
using Microsoft.AspNetCore.Http;

namespace BookShop.Api.Infrastructure.Extensions
{
    public static class SessionExtensions
    {
        private const string ShoppingCartSessionKey = "Shopping_Cart_Id";

        public static string GetShoppingCartId(this ISession session)
        {
            var shoppingCartId = session.GetString(ShoppingCartSessionKey);

            if (shoppingCartId == null)
            {
                shoppingCartId = Guid.NewGuid().ToString();
                session.SetString(ShoppingCartSessionKey, shoppingCartId);
            }

            return shoppingCartId;
        }
    }
}