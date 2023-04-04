using System.ComponentModel.DataAnnotations;

namespace MobileShopWeb.Models
{
    public class ProductColor
    {
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public int ColorId { get; set; }
        public Color Colors { get; set; }
    }
}
