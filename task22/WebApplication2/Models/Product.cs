

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public decimal Price { get; set; } = decimal.Zero;
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; } = null;

    }
}
