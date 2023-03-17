using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnAPI.Models
{
    public class Tour
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "This field is not empty!!!")]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is not empty!!!")]
        public double Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxTourists { get; set; }
        public string? TransportId { get; set; }
        public Transport? Transport { get; set; }
        public  ICollection<ToursCities> ToursCities { get; set; } = new List<ToursCities>();
        public ICollection<ToursSight> ToursSights { get; set; } = new List<ToursSight>();
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}