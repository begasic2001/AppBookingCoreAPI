using AutoMapper;
using LearnAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TourBooking.Dto;
using TourBooking.Interfaces;
using TourBooking.Repositories;

namespace TourBooking.Services
{
    public class TourService : Service<Tour,TourDto> , ITourService
    {
        private readonly IRepository<Tour> _repository;
        private readonly IMapper _mapper;
        TourDatabaseContext _context;
        public TourService(IRepository<Tour> repository, IMapper mapper,TourDatabaseContext context) 
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<Tour>> GetJoin()
        {
            var res = await _context.Tour.Include(tc => tc.ToursCities)
                      .ThenInclude(c => c.City).ToListAsync();
            return res;
        }

        public async Task<Tour> GetJoinById(string id)
        {
            var res = await _context.Tour.Include(tc => tc.ToursCities)
                       .ThenInclude(c => c.City).FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }

        public async Task AddAsyncJoin(TourDto vm)
        {


            var id = Guid.NewGuid().ToString();
            var tour = new Tour()
            {
                Id = id,
                Name = vm.Name,
                Price = vm.Price,
                MaxTourists = vm.MaxTourists,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate

            };
            foreach (var item in vm.CityId)
            {

                tour.ToursCities.Add(new ToursCities()
                {
                    Tour = tour,
                    CityId = item
                });
            }

            _context.Tour.Add(tour);
        }

        public async Task UpdateAsyncJoin(string id , TourDto vm)
        {
            var tour = await _context.Tour.Include(x => x.ToursCities)
                        .ThenInclude(y => y.City).FirstOrDefaultAsync(x => x.Id == id);
            
            var existingIds = tour.ToursCities.Select(x => x.CityId).ToList();
            var selectedIds = vm.CityId.ToList();
            var toAdd = selectedIds.Except(existingIds).ToList();
            var toRemove = existingIds.Except(selectedIds).ToList();
            tour.ToursCities = tour.ToursCities.Where(x => !toRemove.Contains(x.CityId)).ToList();
            foreach (var item in toAdd)
            {
                tour.ToursCities.Add(new ToursCities()
                {
                    CityId = item
                });
            }
            var entity = _mapper.Map<Tour>(tour);
            await _repository.UpdateAsync(entity);
        }
    }
}
