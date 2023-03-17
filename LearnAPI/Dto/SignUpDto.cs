using System.ComponentModel.DataAnnotations;

namespace TourBooking.Dto
{
    public class SignUpDto
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required,EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
