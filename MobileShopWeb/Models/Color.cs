using System.ComponentModel.DataAnnotations;

namespace MobileShopWeb.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string ColorName { get; set; }
        public IList<ProductColor> ProductColors { get; set; }
    }
}
