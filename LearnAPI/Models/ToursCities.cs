using System.ComponentModel.DataAnnotations;

namespace LearnAPI.Models
{
    public class ToursCities
    {
        
        public string TourId { get; set; }
        public Tour Tour { get; set; }
        public string CityId { get; set; }
        public City City { get; set; }
    }
}
