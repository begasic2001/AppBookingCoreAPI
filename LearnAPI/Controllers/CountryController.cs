
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourBooking.Dto;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var a = await _countryService.GetByIdAsync(id);
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(CountryDto country)
        {
            try
            {
                await _countryService.AddAsync(country);
                await _unitOfWork.SaveChangesAsync();
                var newCountry = await _countryService.GetByIdAsync(country.Id);
                return newCountry == null ? NotFound() : Ok(newCountry);
            }
            catch {
                return BadRequest();
             }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id ,CountryDto country)
        {
            try
            {
                await _countryService.UpdateAsync(id,country);
                await _unitOfWork.SaveChangesAsync();
                var editCountry = await _countryService.GetByIdAsync(country.Id);
                return editCountry == null ? NotFound() : Ok(editCountry);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            await _countryService.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Ok($"Delete Successful {id}");
        }
    }
}
