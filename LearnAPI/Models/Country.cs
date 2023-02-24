using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnAPI.Models
{
    public class Country
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "This field is not empty!!!")]
        [Column(TypeName = "nvarchar(255)")]

        public string CountryName { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
