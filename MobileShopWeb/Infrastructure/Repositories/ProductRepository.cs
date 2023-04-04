using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileShopWeb.Context;
using MobileShopWeb.Infrastructure.Interfaces;
using MobileShopWeb.Models;
using MobileShopWeb.ViewModel;

namespace MobileShopWeb.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(Contextdb dbContext) : base(dbContext)
        {
        }

        public ProductAndColorsVM BindProductVM(Product item)
        {
            ProductAndColorsVM productColorsVM = new ProductAndColorsVM();
            productColorsVM.Name = item.ProductName;
            productColorsVM.Price = item.Price;
            productColorsVM.Id = item.Id;
            productColorsVM.BrandName = item.Brand.BrandName;

            return productColorsVM;
        }

        public string BindCommaSeparatedColors(List<string> productColorsList)
        {
            string Colors = String.Empty;

            foreach (var color in productColorsList)
                Colors += color.ToString() + ", ";

            Colors = Colors.Remove(Colors.Length - 2);

            return Colors;
        }

    }
}
