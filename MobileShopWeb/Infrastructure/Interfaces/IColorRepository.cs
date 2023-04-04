using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShopWeb.Models;

namespace MobileShopWeb.Infrastructure.Interfaces
{
    public interface IColorRepository : IGenericRepository<Color>
    {
        Task<List<string>> GetProductColors(int productId);
        Task<List<SelectListItem>> GetProductColorsWithIds(int productId);
        List<SelectListItem> BindDropDownListColor(IEnumerable<Color> colors);
   
    }
}
