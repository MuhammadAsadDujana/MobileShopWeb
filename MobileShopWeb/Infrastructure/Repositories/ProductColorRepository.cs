using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShopWeb.Context;
using MobileShopWeb.Infrastructure.Interfaces;
using MobileShopWeb.Models;

namespace MobileShopWeb.Infrastructure.Repositories
{
    public class ProductColorRepository : GenericRepository<ProductColor>, IProductColorRepository
    {
        public ProductColorRepository(Contextdb dbContext) : base(dbContext)
        {
        }

        public async Task<List<ProductColor>> EditProductColors(string[] selectedColors, int productId)
        {
            List<ProductColor> list = new List<ProductColor>();

            foreach (var item in selectedColors)
            {
                list.Add(new ProductColor
                {
                    ProductId = productId,
                    ColorId = Convert.ToInt32(item),

                });
            }

            return list;
        }


    }
}
