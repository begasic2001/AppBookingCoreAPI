using LearnAPI.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using TourBooking.Dto;
using TourBooking.Helpers;
using TourBooking.Interfaces;

namespace TourBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly TourDatabaseContext _context;
        private readonly ILoggerService _logger;

        public TourController(ITourService tourService, IUnitOfWork unitOfWork,TourDatabaseContext context,ILoggerService logger)
        {
            _tourService = tourService;
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInfo("Get All Country !!!!!!!");
                var a = await _tourService.GetJoin();
               
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
                var a = await _tourService.GetByIdAsync(id);
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(TourDto tour)
        {
            try
            {
                await _tourService.AddAsyncJoin(tour);
                await _unitOfWork.SaveChangesAsync();
                return Ok("Created !!!!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, TourDto tour)
        {
            try
            {
                await _tourService.UpdateAsyncJoin(id, tour);
                //await _tourService.UpdateAsync(id, tour);
                await _unitOfWork.SaveChangesAsync();
                return  Ok("Updated !!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _tourService.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Ok($"Delete Successful {id}");
        }
    }
}
