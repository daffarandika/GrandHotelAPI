using GrandHotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace GrandHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        public readonly GrandHotelContext _context;
        public RoomTypeController(GrandHotelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<RoomType>>> Get()
        {
            var header = Request.Headers;
            string token = header["token"].ToString();
            var validatedToken = CryptoHelper.ValidateToken(token);
            if (validatedToken.IsValid)
            {
                return Ok(await _context.RoomTypes.ToListAsync());
            }
            return BadRequest(validatedToken.Message);
        }
    }
}
