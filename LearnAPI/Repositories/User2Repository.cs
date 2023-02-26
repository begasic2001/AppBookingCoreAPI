using Autofac.Features.AttributeFilters;
using LearnAPI.Interface;

namespace TourBooking.Repositories
{
    public class User2Repository
    {
        private readonly IUserRepository _isUser1;

        public User2Repository([MetadataFilter("ServiceName", "UserRepository")] IUserRepository isUser1)
        {
            _isUser1 = isUser1;
        }
        public IEnumerable<string> GetMessages()
        {
            return new[] { _isUser1.GetMessage(), "Message from USER 2" };
        }
    }
}
