using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShopWeb.Context;
using MobileShopWeb.Infrastructure.Interfaces;
using MobileShopWeb.Models;

namespace MobileShopWeb.Infrastructure.Repositories
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(Contextdb dbContext) : base(dbContext)
        {
        }


        public async Task<List<string>> GetProductColors(int productId)
        {
            List<string> result = new List<string>();

            var productColorList = from c in _dbContext.Colors
                                   join pc in _dbContext.ProductColors on c.Id equals pc.ColorId
                                   where pc.ProductId == productId
                                   select c.ColorName;

            if (productColorList.Count() > 0)
            {
                result = productColorList.ToList();
                return result;
            }
            else
                return result;
        }

        public async Task<List<SelectListItem>> GetProductColorsWithIds(int productId)
        {
            List<SelectListItem> result = new List<SelectListItem>();

            var colorSelected = from c in _dbContext.Colors
                                   join pc in _dbContext.ProductColors on c.Id equals pc.ColorId
                                   where pc.ProductId == productId
                                   select c;

            var allColors = _dbContext.Colors.ToList();
            var colorUnSelected = allColors.Except(colorSelected.ToList());

            if (colorSelected.Count() > 0)
            {
                foreach (var item in colorSelected)
                {
                    result.Add(new SelectListItem()
                    {
                        Text = item.ColorName,
                        Value = item.Id.ToString(),
                        Selected = true
                    });
                }

            }

            if (colorUnSelected.Count() > 0)
            {
                foreach (var item in colorUnSelected)
                {
                    result.Add(new SelectListItem()
                    {
                        Text = item.ColorName,
                        Value = item.Id.ToString(),
                        Selected = false
                    });
                }
            }

            return result;

        }


        public List<SelectListItem> BindDropDownListColor(IEnumerable<Color> colors)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in colors)
            {

                items.Add(new SelectListItem()
                {
                    Text = item.ColorName,
                    Value = item.Id.ToString()
                });

            }

            return items;
        }

       
    }
}
