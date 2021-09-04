using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Product
    {
        // public Product()
        // {
        // }
        // public Product(int id, string title, string description, string category, decimal price, string retailer)
        // {
        //     this.Id = id;
        //     this.Title = title;
        //     this.Description = description;
        //     this.Category = category;
        //     this.Price = price;
        //     this.Retailer = retailer;

        // }
        
        [Key]
        public int Id { get; set; }
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