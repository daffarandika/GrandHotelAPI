using GrandHotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace GrandHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly GrandHotelContext _context;
        public AuthController(GrandHotelContext context)
        {
            _context = context;
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> login (EmployeeDTO req)
        {
            try
            {
                string hashedPassword = CryptoHelper.toSha256(req.Password);
                var employee = _context.Employees.Single(m => m.Name == req.Name && m.Password == hashedPassword);
                return Ok(CryptoHelper.Authenticate(employee));
            } catch (Exception e)
            {
                return BadRequest("employee not found");
            }
        }

    }
}
