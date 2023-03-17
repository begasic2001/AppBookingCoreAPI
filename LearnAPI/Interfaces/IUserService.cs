using LearnAPI.Models;
using Microsoft.AspNetCore.Identity;
using TourBooking.Dto;

namespace TourBooking.Interfaces
{
    public interface IUserService 
    {
        Task<IdentityResult> SignUpAsync(SignUpDto model);
        Task<string> SignInAsync(SignInDto model);
    }
}
