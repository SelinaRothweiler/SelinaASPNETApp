using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;


namespace SelinaASPNETApp.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateProduct(Product product)
        {
            _conn.Execute("INSERT INTO Products (name, price, categoryid, onsale, stocklevel) VALUES (@name, @price, @categoryid, @onsale, @stocklevel);",
                new {name = product.Name, price = product.Price, categoryid = product.CategoryId, product.OnSale, product.StockLevel });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;"); //Regular Dapper

            //return _conn.GetAll<Product>(); // Dapper.Contrib
        }

        public Product GetProductById(int id)
        {
            var products = _conn.Query<Product>("SELECT * FROM PRODUCTS;"); // Regular Dapper
            return products.Where(p => p.ProductId == id).FirstOrDefault();

            //return _conn.Get<Product>(id); // Dapper.Contrib
        }

        public void UpdateProduct(Product p)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price, OnSale = @onsale, StockLevel = @stocklevel, CategoryId = @categoryid WHERE ProductID = @id",
                new { name = p.Name, price = p.Price, categoryid = p.CategoryId, onsale = p.OnSale, stocklevel = p.StockLevel, id = p.ProductId });

            //_conn.Update(p);
        }

        public void DeleteProduct(Product p)
        {
            _conn.Execute("DELETE FROM Reviews WHERE ProductID = @id", new { id = p.ProductId });
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id", new { id = p.ProductId });
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = p.ProductId });
        }
    }
}
