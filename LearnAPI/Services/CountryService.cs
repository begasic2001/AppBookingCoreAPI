using AutoMapper;
using LearnAPI.Models;
using NuGet.Protocol.Core.Types;
using TourBooking.Dto;
using TourBooking.Repositories;

namespace TourBooking.Services
{
    public class CountryService : Service<Country, CountryDto> , ICountryService
    {
        private readonly IRepository<Country> _repository;
        private readonly IMapper _mapper;
        public CountryService(IRepository<Country> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
