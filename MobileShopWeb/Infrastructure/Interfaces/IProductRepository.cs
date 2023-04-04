using MobileShopWeb.Models;
using MobileShopWeb.ViewModel;

namespace MobileShopWeb.Infrastructure.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        ProductAndColorsVM BindProductVM(Product item);
        string BindCommaSeparatedColors(List<string> strings);
    }
}
