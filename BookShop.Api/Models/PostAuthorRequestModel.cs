using System.ComponentModel.DataAnnotations;
using static BookShop.Data.DataConstants;

namespace BookShop.Api.Models
{
    public class PostAuthorRequestModel
    {
        [Required]
        [MaxLength(AuthorFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorLastNameMaxLength)]
        public string LastName { get; set; }
    }
}
