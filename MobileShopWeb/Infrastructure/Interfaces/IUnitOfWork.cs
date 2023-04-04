namespace MobileShopWeb.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IBrandRepository Brands { get; }
        IColorRepository Colors { get; }
        IProductColorRepository ProductColors { get; }
        Task<int> Save();
    }
}
