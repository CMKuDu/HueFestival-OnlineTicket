using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Models;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvnetsController : ControllerBase
    {
        private readonly DataContext _context;

        public EvnetsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Evnets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evnet>>> GetEvents()
        {
          if (_context.Events == null)
          {
              return NotFound();
          }
            return await _context.Events.ToListAsync();
        }

        // GET: api/Evnets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evnet>> GetEvnet(int id)
        {
          if (_context.Events == null)
          {
              return NotFound();
          }
            var evnet = await _context.Events.FindAsync(id);

            if (evnet == null)
            {
                return NotFound();
            }

            return evnet;
        }

        // PUT: api/Evnets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvnet(int id, Evnet evnet)
        {
            if (id != evnet.Id)
            {
                return BadRequest();
            }

            _context.Entry(evnet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvnetExists(id))
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

        // POST: api/Evnets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evnet>> PostEvnet(Evnet evnet)
        {
          if (_context.Events == null)
          {
              return Problem("Entity set 'DataContext.Events'  is null.");
          }
            _context.Events.Add(evnet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvnet", new { id = evnet.Id }, evnet);
        }

        // DELETE: api/Evnets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvnet(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            var evnet = await _context.Events.FindAsync(id);
            if (evnet == null)
            {
                return NotFound();
            }

            _context.Events.Remove(evnet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvnetExists(int id)
        {
            return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
