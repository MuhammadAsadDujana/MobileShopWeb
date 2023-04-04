using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShopWeb.Models;

namespace MobileShopWeb.Infrastructure.Interfaces
{
    public interface IProductColorRepository : IGenericRepository<ProductColor>
    {
        Task<List<ProductColor>> EditProductColors(string[] selectedList, int productId);
    }
}
