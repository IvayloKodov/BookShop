using System.Linq;
using System.Threading.Tasks;
using BookShop.Api.Infrastructure.Extensions;
using BookShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{
    public class ShoppingCartController : BaseApiController
    {
        private readonly IShoppingCartManager _shoppingCartManager;
        private readonly ICartItemsService _cartItemsService;

        public ShoppingCartController(IShoppingCartManager shoppingCartManager,
                                      ICartItemsService cartItemsService)
        {
            _shoppingCartManager = shoppingCartManager;
            _cartItemsService = cartItemsService;
        }

        [HttpGet]
        public async Task<IActionResult> Items()
        {
            var shoppingCartItems = _shoppingCartManager.GetItems(HttpContext.Session.GetShoppingCartId()).ToList();

            var cartItemServiceModels = await _cartItemsService.GetCartsItemsServiceModelAsync(shoppingCartItems);

            return Ok(cartItemServiceModels);
        }

        [HttpPost]
        public IActionResult AddToCart(int bookId)
        {
            var shoppingCartId = HttpContext.Session.GetShoppingCartId();

            _shoppingCartManager.AddToShoppingCart(shoppingCartId, bookId);

            return RedirectToAction(nameof(Items));
        }
    }
}