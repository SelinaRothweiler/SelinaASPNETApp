using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelinaASPNETApp.Models
{
        public interface IProductRepository
        {
            public IEnumerable<Product> GetAllProducts();
            public Product GetProductById(int id);
            public void CreateProduct(Product product);
            public void UpdateProduct(Product p);
            public void DeleteProduct(Product p);
            //public IEnumerable<Category> GetCategories();
            //public Product AssignCategory();
        }
}
