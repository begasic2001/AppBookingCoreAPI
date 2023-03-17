using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LearnAPI.Models
{
    public class User : IdentityUser
    {
        [Column(TypeName = "nvarchar(255)")]
        public string? Avatar { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
