using System.ComponentModel.DataAnnotations;

namespace QuitQ.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public required string Name { get; set; }
        [Required, MaxLength(500)]
        public required string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public required string Category { get; set; }
        public required string ImageUrl { get; set; }
        public int SellerId { get; set; } // Reference to Seller (User Id)
    }
}
