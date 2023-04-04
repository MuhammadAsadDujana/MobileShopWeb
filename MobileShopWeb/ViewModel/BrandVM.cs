using MobileShopWeb.Models;

namespace MobileShopWeb.ViewModel
{
    public class BrandVM
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<int> TotalProducts { get; set; }
    }
}
