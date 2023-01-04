using GrandHotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GrandHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly GrandHotelContext _context;
        public EmployeeController(GrandHotelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            var header = Request.Headers;
            string token = header["token"].ToString();
            if (token == null)
            {
                return BadRequest("token must be provided");
            }
            if (CryptoHelper.IsTokenValid(token))
            {
                return Ok(await _context.Employees
                    .Include(p => p.CleaningRooms)
                    .ToListAsync());
            }
            return BadRequest("Token is invalid");
        }
        [HttpPost]
        public async Task<ActionResult<string>> Post(Employee employee)
        {
            employee.Password = CryptoHelper.toSha256(employee.Password);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok("Successfully added a new employee");
        }
    }
}
