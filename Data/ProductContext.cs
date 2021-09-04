using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data {
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> opt): base(opt)
        {
            
        }

        public DbSet<Product> Products { get; set;}
    }

}