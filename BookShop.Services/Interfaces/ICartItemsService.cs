using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Services.Models;
using BookShop.Services.Models.Shopping;

namespace BookShop.Services.Interfaces
{
    public interface ICartItemsService
    {
        Task<IEnumerable<CartItemServiceModel>> GetCartsItemsServiceModelAsync(List<CartItem> items);
    }
}