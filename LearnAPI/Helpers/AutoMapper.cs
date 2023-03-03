using AutoMapper;
using LearnAPI.Models;
using TourBooking.Dto;

namespace TourBooking.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {
            CreateMap<Country, CountryDto>().ReverseMap();
        }
    }
}
