using System.Collections.Generic;
using Ecommerce.Models;

namespace Ecommerce.Data 
{
    public interface IProductRepo
    {
        bool SaveChanges();
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(Product p);
    }
}