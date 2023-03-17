using LearnAPI.Models;
using Microsoft.Build.Framework;

namespace TourBooking.Dto
{
    public class CountryDto : Entity
    {
        [Required]
        public string CountryName { get; set; }
    }
}
