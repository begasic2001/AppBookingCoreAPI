using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public TransportController(ITransportService transportService, IUnitOfWork unitOfWork)
        {
            _transportService = transportService;
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
        public async Task<IActionResult> Add(TransportDto transport)
        {
            try
            {
                await _transportService.AddAsync(transport);
                await _unitOfWork.SaveChangesAsync();
                var newTransport = await _transportService.GetByIdAsync(transport.Id);
                return newTransport == null ? NotFound() : Ok(newTransport);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, TransportDto transport)
        {
            try
            {
                await _transportService.UpdateAsync(id, transport);
                await _unitOfWork.SaveChangesAsync();
                var editTransport = await _transportService.GetByIdAsync(transport.Id);
                return editTransport == null ? NotFound() : Ok(editTransport);
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
