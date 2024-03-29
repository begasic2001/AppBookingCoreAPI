﻿using LearnAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourBooking.Dto
{
    public class TourDto : Entity
    {
        public string Name { get; set; }
       
        public double Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxTourists { get; set; }
        public string? TransportId { get; set; }
        public string[] CityId { get; set; }
        public string[] SightId { get; set; }
    }
}
