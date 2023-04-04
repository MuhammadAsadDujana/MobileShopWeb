using MobileShopWeb.Models;

namespace MobileShopWeb.ViewModel
{
    public class ProductVM
    {
        public IEnumerable<Product> Products { get; set; }

        public List<ProductAndColorsVM> productAndColors { get; set; } = new List<ProductAndColorsVM>();

        public Product Product { get; set; }
    }
}
