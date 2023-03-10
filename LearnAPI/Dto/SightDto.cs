using LearnAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourBooking.Dto
{
    public class SightDto : Entity
    {
        
        public string SightName { get; set; }
       
        public double SightForMoney { get; set; }
        public string Picture { get; set; }
        public CityDto? City { get; set; }
    }
}
