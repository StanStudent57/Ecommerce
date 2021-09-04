
using System;
using System.Collections.Generic;
using System.Linq;
using Ecommerce.Models;

namespace Ecommerce.Data {
    public class SqlProductRepo : IProductRepo
    {
        private readonly ProductContext _context;

        public SqlProductRepo(ProductContext context)
        {
            _context = context;
        }

        public void AddProduct(Product p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
             _context.Products.Add(p);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges() {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProduct(Product p)
        {
        }

        public void DeleteProduct(Product p)
        {
            if(p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Products.Remove(p);
        }
    }
}