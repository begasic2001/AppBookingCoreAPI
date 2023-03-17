using LearnAPI.Models;
using TourBooking.Dto;

namespace TourBooking.Interfaces
{
    public interface ITourService : IService<Tour,TourDto>
    {
        Task<IEnumerable<object>> GetJoin();
        Task<Tour> GetJoinById(string id);
        Task AddAsyncJoin(TourDto tour);
        Task UpdateAsyncJoin(string id, TourDto tour);

    }
}
