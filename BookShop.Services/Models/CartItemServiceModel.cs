using BookShop.Common.Mapping;
using BookShop.Services.Models.Shopping;

namespace BookShop.Services.Models
{
    public class CartItemServiceModel : IMapFrom<CartItem>
    {
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }
    }
}
