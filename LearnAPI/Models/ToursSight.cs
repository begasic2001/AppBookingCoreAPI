using System.ComponentModel.DataAnnotations;

namespace LearnAPI.Models
{
    public class ToursSight
    {
        public int Id { get; set; }
        public string? TourId { get; set; }
        public string? SightId { get; set; }
        public Tour? Tour { get; set; }
        public Sight? Sight { get; set; }

    }
}
