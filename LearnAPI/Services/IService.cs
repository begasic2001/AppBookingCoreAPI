using System.Linq.Expressions;

namespace TourBooking.Services
{
    public interface IService<TEntity,TDto>
    {
        Task AddAsync(TDto tDto);

        Task DeleteAsync(string id);

        Task<IEnumerable<TDto>> GetAll(Expression<Func<TDto, bool>> expression = null);

        Task<TDto> GetByIdAsync(string id);
        Task UpdateAsync(string id ,TDto entityTDto);
        Task<TDto> GetFirstAsync(Expression<Func<TDto, bool>> expression);
    }
}
