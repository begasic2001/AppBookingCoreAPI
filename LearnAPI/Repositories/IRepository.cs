using System.Linq.Expressions;
using TourBooking.Dto;

namespace TourBooking.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetAll(Expression<Func<T,bool>> expression = null);
        Task<T> GetByIdAsync(string id);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> expression );
    }
}
