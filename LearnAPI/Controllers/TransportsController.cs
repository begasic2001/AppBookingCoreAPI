using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LearnAPI.Models;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportsController : ControllerBase
    {
        private readonly TourDatabaseContext _context;

        public TransportsController(TourDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Transports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transport>>> GetTransport()
        {
            return await _context.Transport.ToListAsync();
        }

        // GET: api/Transports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transport>> GetTransport(string id)
        {
            var transport = await _context.Transport.FindAsync(id);

            if (transport == null)
            {
                return NotFound();
            }

            return Ok(transport);
        }

        // PUT: api/Transports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransport(string id, Transport transport)
        {
            if (id != transport.Id)
            {
                return BadRequest();
            }

            _context.Entry(transport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transport>> PostTransport([FromBody]Transport transport)
        {
            Console.Write(transport);
            _context.Transport.Add(transport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransportExists(transport.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTransport", new { id = transport.Id }, transport);
        }

        // DELETE: api/Transports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransport(string id)
        {
            var transport = await _context.Transport.FindAsync(id);
            if (transport == null)
            {
                return NotFound();
            }

            _context.Transport.Remove(transport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransportExists(string id)
        {
            return _context.Transport.Any(e => e.Id == id);
        }
    }
}
