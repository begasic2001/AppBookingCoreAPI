using LearnAPI.Interface;
using LearnAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourBooking.Repositories;

namespace TourBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController 
    {
        private readonly IUserRepository _user;

        public UserController(IUserRepository user)
        {
            _user = user;
        }
        [HttpGet]
        public string Get()
        {
            return _user.GetMessage();
        }
        [HttpPost]
        public void Post(Transport transport)
        {
            Console.WriteLine(transport.TransportName);
        }
    }
}
