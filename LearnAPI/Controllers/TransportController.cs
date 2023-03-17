using LearnAPI.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourBooking.Dto;
using TourBooking.Helpers;
using TourBooking.Interfaces;

namespace TourBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _transportService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _logger;
        private readonly TourDatabaseContext _context;

        public TransportController(ITransportService transportService, IUnitOfWork unitOfWork, ILoggerService logger,TourDatabaseContext context)
        {
            _transportService = transportService;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInfo("Get all transport!!!!");
                var a = await _transportService.GetAll();
                return Ok(a);
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                _logger.LogInfo($"Get transport by id {id}");
                var a = await _transportService.GetByIdAsync(id);
                return Ok(a);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(TransportDto transport)
        {
            try
            {
                _logger.LogInfo("Create new transport!!!!");
                var hasTransport = _context.Transport.Where(c => c.TransportName.Trim().ToLower() == transport.TransportName.Trim().ToLower()).FirstOrDefault();
                if (hasTransport != null)
                {
                    return Conflict($"{transport.TransportName} already exists!");
                }
                transport.TransportName = transport.TransportName.Trim().ToLower();
                await _transportService.AddAsync(transport);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInfo("Create Successfully transport!!!!");
                var newTransport = await _transportService.GetByIdAsync(transport.Id);
                return newTransport == null ? NotFound() : Ok(newTransport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, TransportDto transport)
        {
            try
            {
                _logger.LogInfo($"Edit transport by id {id}");
                if(transport.Id != id)
                {
                    return NotFound(id);
                }
                //var hasTransport = _context.Transport.Where(c => c.TransportName.Trim().ToLower() == transport.TransportName.Trim().ToLower() && c.Id==id).FirstOrDefault();
                //if (hasTransport != null)
                //{
                //    return Conflict($"{transport.TransportName} already exists!");
                //}
                transport.TransportName = transport.TransportName.Trim().ToLower();
                await _transportService.UpdateAsync(id, transport);
                await _unitOfWork.SaveChangesAsync();
                var editTransport = await _transportService.GetByIdAsync(transport.Id);
                return editTransport == null ? NotFound() : Ok(editTransport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                _logger.LogInfo($"Delete transport by id {id}");
                
                    await _transportService.DeleteAsync(id);
                    await _unitOfWork.SaveChangesAsync();
                    _logger.LogInfo($"Delete successfully {id}");
                    return Ok($"Delete Successful {id}");
               
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            
        }
    }
}
