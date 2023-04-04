using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShopWeb.Models;
using MobileShopWeb.ViewModel;
using System.Collections.Generic;

namespace MobileShopWeb.Infrastructure.Interfaces
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<IEnumerable<BrandTotalProductsVM>> GetBrandTotalProducts();
        List<SelectListItem> SelectedBrandDropDownList(Product product);
        List<SelectListItem> BindDropDownListBrand(IEnumerable<Brand> brands);
    }
}
