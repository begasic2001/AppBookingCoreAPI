using AutoMapper;
using LearnAPI.Models;
using TourBooking.Dto;

namespace TourBooking.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Sight, SightDto>().ReverseMap();
            CreateMap<Transport, TransportDto>().ReverseMap();
            CreateMap<Tour, TourDto>().ReverseMap();
        }
    }
}
