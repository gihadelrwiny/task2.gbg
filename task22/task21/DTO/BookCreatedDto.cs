using System.ComponentModel.DataAnnotations;

namespace task21.DTO
{
    public class BookCreatedDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [MaxLength(100)]
        public string Author{ get; set; }
    }
}
