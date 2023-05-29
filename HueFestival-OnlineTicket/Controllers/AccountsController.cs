using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Models;
using BC = BCrypt.Net.BCrypt;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;


namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _context;
        public IConfiguration _configuration;


        public AccountsController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        [HttpGet("All_in4")]
        public async Task<ActionResult<IEnumerable<Account>>> Account()
        {
            if(_context.Accounts == null)
            {
                return BadRequest("Something wrong");
            }
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/Accounts
        [HttpGet("My_in4")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
           
            var tk = _context.Customers.Include(x => x.Locations).SingleOrDefault(x => x.Id == id);
            if (tk != null)
            {
                var lsThongTin = _context
                    .TicketBooks
                    .Include(x => x.Transacstatuss)
                    .AsNoTracking()
                    .Where(x => x.CustomerId == tk.Id)
                    .OrderByDescending(x => x.Datecreatebook)
                    .ToList();
                return Ok(tk);
            }
                return BadRequest("Something wrong");


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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
        [HttpPost("Register")]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'DataContext.Accounts'  is null.");
            }
            account.Password = BC.HashPassword(account.Password);
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet("Login")]
        public async Task<Account>Login(string phone,string password)
        {
            Account ac = await _context.Accounts.FirstOrDefaultAsync(u => u.Phone == phone);
            if (ac != null && BC.Verify(password, ac.Password))
            {
                return ac;
            }
            return null;
        }
        [HttpPost("fPassword")]
        public async Task<IActionResult> ForgotPassword(string phoneNumber)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(u => u.Phone == phoneNumber);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            user.PasswordResetToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();
            return Ok(user.PasswordResetToken);
        }
        [HttpPost("rPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);
            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest("User not found");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Password = hashedPassword;

            await _context.SaveChangesAsync();
            return Ok("Done");
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }



    }

}
