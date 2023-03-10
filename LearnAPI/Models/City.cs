using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnAPI.Models
{
    public class City
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "This field is not empty!!!")]
        [Column(TypeName = "nvarchar(255)")]
        public string CityName { get; set; }
        public ICollection<Sight> ?Sights { get; set; }
        public string ?CountryId { get; set; }
        public Country ?Country { get; set; }  
        public ICollection<ToursCities> ToursCities { get; set; } = new List<ToursCities>();
    }
}
