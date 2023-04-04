using System.Linq.Expressions;

namespace MobileShopWeb.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Expression<Func<T, bool>> predicate, string? includeProperties = null);
        Task<IEnumerable<T>> GetAll(string? includeProperties = null);
        Task<IEnumerable<T>> GetAllById(Expression<Func<T, bool>> predicate, string? includeProperties = null);

        Task AddRange(List<T> entities);
        Task Add(T entity);
        void Update(T entity);
        void UpdateRange(List<T> entity);
        void Delete(T entity);
        void DeleteRange(List<T> entity);

    }
}
