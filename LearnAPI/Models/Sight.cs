using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnAPI.Models
{
    public class Sight
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "This field is not empty!!!")]
        [Column(TypeName = "nvarchar(255)")]
        public string SightName { get; set; }
        [Required(ErrorMessage = "This field is not empty!!!")]
        public double SightForMoney { get; set;}
        [Required(ErrorMessage = "This field is not empty!!!")]
        [Column(TypeName = "nvarchar(255)")]
        public string Picture { get; set;}
        public City City { get; set; }
        public ICollection<ToursSight>? ToursSights { get; set; }
    }
}
