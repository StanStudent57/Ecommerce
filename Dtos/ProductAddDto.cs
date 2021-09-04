using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos
{
    public class ProductAddDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required
        ]public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Retailer { get; set; }
    }
}