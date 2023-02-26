using LearnAPI.Interface;
using LearnAPI.Models;

namespace TourBooking.Repositories
{
    public class UserRepository : IUserRepository
    {
        public string GetMessage()
        {
            return "Message from USER 1";
        }
    }
}
