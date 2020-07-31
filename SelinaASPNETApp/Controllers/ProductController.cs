using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelinaASPNETApp.Models;

namespace SelinaASPNETApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        //GET {controller}
        public IActionResult Index()
        {
            var products = _repo.GetAllProducts();
            return View(products);
        }

        //GET {controller}/{action}/{id}        
        public IActionResult ViewProduct(int id)
        {
            var product = _repo.GetProductById(id);
            return View(product);
        }

        //GET {controller}/{action}
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //POST {controller}/{action}      
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateProduct(p);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UpdateProduct(int id)
        {
            var product = _repo.GetProductById(id);

            _repo.UpdateProduct(product);

            if (product == null)
            {
                return View("ProductNotFound");
            }

            return View(product);
        }

        public IActionResult UpdateProductToDatabase(Product p)
        {
            _repo.UpdateProduct(p);

            return RedirectToAction("ViewProduct", new { id = p.ProductId });
        }

        public IActionResult DeleteProduct(Product p)
        {
            _repo.DeleteProduct(p);
            return RedirectToAction("Index");
        }

    }
}

//IIS Server issues: Change the port number under App URL within the Debug tab under Project Properties.
