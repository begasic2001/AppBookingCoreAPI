using AutoMapper;
using AutoMapper.QueryableExtensions;
using LearnAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using NuGet.Protocol.Core.Types;
using System.Configuration;
using System.Linq.Expressions;
using TourBooking.Dto;
using TourBooking.Interfaces;
using TourBooking.Repositories;

namespace TourBooking.Services
{
    public class CityService : Service<City, CityDto>, ICityService
    {
        private readonly IRepository<City> _repository;
        private readonly IMapper _mapper;
        private readonly TourDatabaseContext _context;

        public CityService(IRepository<City> repository, IMapper mapper, TourDatabaseContext context) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }
    }
}
