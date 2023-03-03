using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourBooking.Helpers;
using TourBooking.Services;

namespace TourBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IUnitOfWork _unitOfWork;

        public CountryController(ICountryService countryService, IUnitOfWork unitOfWork)
        {
            _countryService = countryService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var a = await _countryService.GetAll();
                
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
