using AutoMapper;
using LearnAPI.Models;
using TourBooking.Dto;
using TourBooking.Interfaces;
using TourBooking.Repositories;

namespace TourBooking.Services
{
    public class SightService : Service<Sight, SightDto>, ISightService
    {
        private readonly IRepository<Sight> _repository;
        private readonly IMapper _mapper;
        public SightService(IRepository<Sight> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
