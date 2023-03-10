﻿using LearnAPI.Models;
using System.Linq.Expressions;
using TourBooking.Dto;

namespace TourBooking.Interfaces
{
    public interface ICityService : IService<City, CityDto>
    {
        //IEnumerable<object> GetJoin();
        IEnumerable<object> GetJoinById(string id);
    }
}
