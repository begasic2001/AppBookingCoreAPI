using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LearnAPI.Models
{
    public class User
    {
        [Key]   
        public string Id { get; set; }
        [Required]
        [Column(TypeName="nvarchar(255)")] 
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Phone { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Avatar { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
