using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileShopWeb.Context;
using MobileShopWeb.Infrastructure.Interfaces;
using MobileShopWeb.Models;
using System.Linq.Expressions;

namespace MobileShopWeb.Infrastructure.Repositories
{
    public  class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly Contextdb _dbContext;

        protected GenericRepository(Contextdb dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRange(List<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public async Task Add(T entity)
        {
           await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(List<T> entity)
        {
            _dbContext.Set<T>().RemoveRange(entity);
        }

        public async Task<IEnumerable<T>> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
         //   return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate, string? includeProperties = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query = query.Where(predicate);

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync();

            // return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllById(Expression<Func<T, bool>> predicate, string? includeProperties = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query = query.Where(predicate);

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
            // return await _dbContext.Set<T>().FindAsync(id);
        }

        public  void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public  void UpdateRange(List<T> entity)
        {
            _dbContext.Set<T>().UpdateRange(entity);
        }


    }
}
