using System.Collections.Generic;

namespace BookShop.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public List<BookCategory> Books { get; set; } = new List<BookCategory>();
    }
}