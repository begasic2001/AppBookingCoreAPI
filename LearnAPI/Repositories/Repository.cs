using LearnAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TourBooking.Dto;

namespace TourBooking.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TourDatabaseContext _context;
        private DbSet<T> _entity;

        public Repository(TourDatabaseContext context)
        {
            _context = context;
            _entity = _context.Set<T>();    
        }
        public async Task AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {
            _entity.Remove(entity);
            return Task.CompletedTask;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            var result = _entity.AsNoTracking();
            if(expression != null)
            {
                result = result.Where(expression);  
            }
            return result;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> expression)
        {
            return await _entity.FirstOrDefaultAsync(expression);
        }

        public Task UpdateAsync(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
