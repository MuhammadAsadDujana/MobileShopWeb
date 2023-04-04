using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MobileShopWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }

        [ValidateNever]
        public Brand Brand { get; set; }

        [ValidateNever]
        public IList<ProductColor> ProductColors { get; set; }
    }
}
