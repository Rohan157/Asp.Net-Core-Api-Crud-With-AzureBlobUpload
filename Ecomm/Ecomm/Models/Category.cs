using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Models
{
    public class Category
    {
        public int Id { get; set; } = 0;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage ="Display Order Must be greater than 0")]
        public int DisplayOrder { get; set; } = 0;
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        [NotMapped]
        public IFormFile CategoryImage { get; set; } = null;
        public string CategoryImagePath { get; set; } = string.Empty;
    }
}
