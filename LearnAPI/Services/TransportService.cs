using AutoMapper;
using LearnAPI.Models;
using NuGet.Protocol.Core.Types;
using TourBooking.Dto;
using TourBooking.Interfaces;
using TourBooking.Repositories;

namespace TourBooking.Services
{
    public class TransportService : Service<Transport,TransportDto> , ITransportService
    {
        private readonly IRepository<Transport> _repository;
        private readonly IMapper _mapper;
        public TransportService(IRepository<Transport> repository,IMapper mapper)
            :base(repository,mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
