using System;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}