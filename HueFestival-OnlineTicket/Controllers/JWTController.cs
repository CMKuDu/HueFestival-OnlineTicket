using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace HueFestival_OnlineTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly DataContext _context;
        public JWTController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Account account)
        {
            if (account != null && account.Phone != null && account.Password != null)
            {
                var userData = await GetUser(account.Phone, account.Password);
                var jwt = _configuration.GetSection("Jwt").Get<JwtHeaderParameterNames>();
                if (account != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        //new Claim("Id", account.Id.ToString()),
                        new Claim("Name", account.LoginAccount),
                        new Claim("Password", account.Password),
                        new Claim("Email", account.Email),
                        new Claim("PhoneNumber", account.Phone),
                        
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid");
                }
            }
            else
            {
                return BadRequest("Invalid");
            }
        }
        [HttpGet]
        public async Task<Account> GetUser(string phone, string password)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Phone == phone && a.Password == password);
        }

    }
}
