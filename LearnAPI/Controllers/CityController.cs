using LearnAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TourBooking.Dto;
using TourBooking.Helpers;
using TourBooking.Interfaces;

namespace TourBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IUnitOfWork _unitOfWork;

        public CityController(ICityService cityService, IUnitOfWork unitOfWork)
        {
            _cityService = cityService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = _cityService.GetAllJoin(new string[]{"Country"}).Select(x => 
                    new
                    {
                        Id = x.Id,
                        CityName = x.CityName,
                        CountryName = x.Country.CountryName
                    }
                );
                return Ok(res);
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
                var a =  _cityService.GetMultiJoin(c=>c.Id == id, new string[] { "Country" }).Select(x =>
                    new
                    {
                        Id = x.Id,
                        CityName = x.CityName,
                        CountryName = x.Country.CountryName
                    }
                );
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(CityDto city)
        {
            try
            {
                Console.WriteLine(city.CountryId);
                await _cityService.AddAsync(city);
                await _unitOfWork.SaveChangesAsync();
                var newCity = await _cityService.GetByIdAsync(city.Id);
                return newCity == null ? NotFound() : Ok(newCity);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, CityDto city)
        {
            try
            {
                await _cityService.UpdateAsync(id, city);
                await _unitOfWork.SaveChangesAsync();
                var editCity = await _cityService.GetByIdAsync(city.Id);
                return editCity == null ? NotFound() : Ok(editCity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            await _cityService.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Ok($"Delete Successful {id}");
        }
    }
}
