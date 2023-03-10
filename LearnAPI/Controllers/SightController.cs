using LearnAPI.Models;
using Microsoft.AspNetCore.Mvc;
using TourBooking.Dto;
using TourBooking.Helpers;
using TourBooking.Interfaces;

namespace TourBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightController : ControllerBase
    {
        private readonly ISightService _transportService;
        private readonly IUnitOfWork _unitOfWork;

        public SightController(ISightService sightService, IUnitOfWork unitOfWork)
        {
            _transportService = sightService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                //var res = _transportService.GetJoin();

                var a = await _transportService.GetAll();
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
                var a = await _transportService.GetByIdAsync(id);
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(SightDto sight)
        {
            try
            {
                await _transportService.AddAsync(sight);
                await _unitOfWork.SaveChangesAsync();
                var newSight = await _transportService.GetByIdAsync(sight.Id);
                return newSight == null ? NotFound() : Ok(newSight);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, SightDto sight)
        {
            try
            {
                await _transportService.UpdateAsync(id, sight);
                await _unitOfWork.SaveChangesAsync();
                var editSight = await _transportService.GetByIdAsync(sight.Id);
                return editSight == null ? NotFound() : Ok(editSight);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            await _transportService.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Ok($"Delete Successful {id}");
        }
    }
}
