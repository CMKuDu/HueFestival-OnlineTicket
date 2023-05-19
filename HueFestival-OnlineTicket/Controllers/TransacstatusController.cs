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
    public class TransacstatusController : ControllerBase
    {
        private readonly DataContext _context;

        public TransacstatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Transacstatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacstatus>>> GetTransacstatus()
        {
          if (_context.Transacstatus == null)
          {
              return NotFound();
          }
            return await _context.Transacstatus.ToListAsync();
        }

        // GET: api/Transacstatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transacstatus>> GetTransacstatus(int id)
        {
          if (_context.Transacstatus == null)
          {
              return NotFound();
          }
            var transacstatus = await _context.Transacstatus.FindAsync(id);

            if (transacstatus == null)
            {
                return NotFound();
            }

            return transacstatus;
        }

        // PUT: api/Transacstatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransacstatus(int id, Transacstatus transacstatus)
        {
            if (id != transacstatus.id)
            {
                return BadRequest();
            }

            _context.Entry(transacstatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransacstatusExists(id))
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

        // POST: api/Transacstatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transacstatus>> PostTransacstatus(Transacstatus transacstatus)
        {
          if (_context.Transacstatus == null)
          {
              return Problem("Entity set 'DataContext.Transacstatus'  is null.");
          }
            _context.Transacstatus.Add(transacstatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransacstatus", new { id = transacstatus.id }, transacstatus);
        }

        // DELETE: api/Transacstatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransacstatus(int id)
        {
            if (_context.Transacstatus == null)
            {
                return NotFound();
            }
            var transacstatus = await _context.Transacstatus.FindAsync(id);
            if (transacstatus == null)
            {
                return NotFound();
            }

            _context.Transacstatus.Remove(transacstatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransacstatusExists(int id)
        {
            return (_context.Transacstatus?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
