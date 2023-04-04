using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShopWeb.Models;

namespace MobileShopWeb.ViewModel
{
    public class CreateProductVM
    {
        public Product Products { get; set; }
        public List<SelectListItem> BrandsListItem { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ColorsListItem { get; set; } = new List<SelectListItem>();

        public string[] Color { get; set; }
    }
}
