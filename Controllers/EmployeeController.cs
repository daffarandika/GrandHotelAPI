﻿using GrandHotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            var validatedToken = CryptoHelper.ValidateToken(token);
            if (validatedToken.IsValid)
            {
                return Ok(await _context.Employees.ToListAsync());
            }
            return BadRequest(validatedToken.Message);
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
