using LearnAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourBooking.Dto
{
    public class CityDto : Entity
    {
 
        public string CityName { get; set; }
        public string CountryId { get; set; }
    }
}
