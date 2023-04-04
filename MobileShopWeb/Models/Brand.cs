using System.ComponentModel.DataAnnotations;

namespace MobileShopWeb.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
    }
}
