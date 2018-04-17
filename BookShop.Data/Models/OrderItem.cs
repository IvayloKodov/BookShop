namespace BookShop.Data.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int BookId { get; set; }

        public decimal BookPrice { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
