using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using Dapper.Contrib.Extensions;

namespace SelinaASPNETApp.Models
{
    public class Product
    {
        //[Dapper.Contrib.Extensions.Key]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "You must give a product name!")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must give the product a price, 0 if free!")]
        public decimal Price { get; set; }

        [Display(Name = "Category ID")]
        [Required(ErrorMessage = "You must provide a category ID!")]
        public int CategoryId { get; set; }

        [Display(Name = "On Sale")]
        [Required(ErrorMessage = "You must give a 0 if the item is on sale or a 1 if the item is on sale!")]
        public int OnSale { get; set; }

        [Display(Name = "Amount in Stock")]
        [Required(ErrorMessage = "You must how many are in stock!")]
        public int StockLevel { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
