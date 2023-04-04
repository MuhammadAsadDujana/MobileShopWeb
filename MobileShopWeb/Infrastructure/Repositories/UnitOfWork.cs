using Microsoft.EntityFrameworkCore;
using MobileShopWeb.Context;
using MobileShopWeb.Infrastructure.Interfaces;
using MobileShopWeb.Models;

namespace MobileShopWeb.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contextdb _dbContext;
        public IProductRepository Products { get; private set; }

        public IBrandRepository Brands { get; private set; }

        public IColorRepository Colors { get; private set; }

        public IProductColorRepository ProductColors { get; private set; }

        public UnitOfWork(Contextdb dbContext)
        {
            _dbContext = dbContext;
            Products = new ProductRepository(_dbContext);
            Brands= new BrandRepository(_dbContext);
            Colors = new ColorRepository(_dbContext);
            ProductColors = new ProductColorRepository(_dbContext);
        }


        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }


    }
}
