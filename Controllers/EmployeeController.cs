using GrandHotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return Ok(await _context.Employees
                .Include(p => p.CleaningRooms)
                .ToListAsync());
        }
    }
}
