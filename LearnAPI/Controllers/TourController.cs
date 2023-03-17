using LearnAPI.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Security.Cryptography.Xml;
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
                _logger.LogInfo("Get All Tour !!!!!!!");
                var a = await _tourService.GetJoin();
               
                return Ok(a);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                _logger.LogInfo($"Get tour by id {id}");
                var a = await _tourService.GetByIdAsync(id);
                return Ok(a);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(TourDto tour)
        {
            try
            {
                _logger.LogInfo("Create new tour !!!!");
                var hasTour = _context.Tour.Where(c => c.Name.Trim().ToLower() == tour.Name.Trim().ToLower()).FirstOrDefault();
                if (hasTour != null)
                {
                    return Conflict($"{tour.Name} already exists!");
                }
                tour.Name = tour.Name.Trim().ToLower();
                await _tourService.AddAsyncJoin(tour);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInfo("Create successfull !!!");
                return Ok("Created !!!!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, TourDto tour)
        {
            try
            {
                _logger.LogInfo($"Edit tour by id {id}");
                if(tour.Id != id)
                {
                    return NotFound(id);
                }
                //var hasTour = _context.Tour.Where(c => c.Name.Trim().ToLower() == tour.Name.Trim().ToLower() && c.Id == id).FirstOrDefault();
                //if (hasTour != null)
                //{
                //    return Conflict($"{tour.Name} already exists!");
                //}
                
                tour.Name = tour.Name.Trim().ToLower();
                await _tourService.UpdateAsyncJoin(id, tour);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInfo($"Update succesfull {id}");
                return  Ok("Updated !!!!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                _logger.LogInfo($"Delete tour by id {id}");
              
                    await _tourService.DeleteAsync(id);
                    await _unitOfWork.SaveChangesAsync();
                    _logger.LogInfo($"Delete Successful id {id}");
                    return Ok($"Delete Successful {id}");
               
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }
    }
}
