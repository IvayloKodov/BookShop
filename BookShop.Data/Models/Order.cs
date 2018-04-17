using System.Collections.Generic; 

namespace BookShop.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }
         
        public decimal TotalPrice { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
