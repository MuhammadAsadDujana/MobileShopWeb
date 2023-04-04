using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MobileShopWeb.Context;
using MobileShopWeb.Infrastructure.Interfaces;
using MobileShopWeb.Models;
using MobileShopWeb.ViewModel;
using System.Collections.Generic;

namespace MobileShopWeb.Infrastructure.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(Contextdb dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<BrandTotalProductsVM>> GetBrandTotalProducts()
        {
            var res = await _dbContext.BrandTotalProducts.FromSqlRaw("EXEC sp_GetTotalProducts").ToListAsync();
            return res;
        }

        public  List<SelectListItem> SelectedBrandDropDownList(Product product)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem()
            {
                Text = product.Brand.BrandName,
                Value = product.BrandId.ToString(),
                Selected = true
            });

            return items;
        }

        public List<SelectListItem> BindDropDownListBrand(IEnumerable<Brand> brands)
        {
            List <SelectListItem> items = new List<SelectListItem>();
            foreach (var item in brands)
            {

                items.Add(new SelectListItem()
                {
                    Text = item.BrandName,
                    Value = item.Id.ToString()
                });

            }

            return items;
        }

  
    }
}
