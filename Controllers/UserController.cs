using EcommerceApp.data;
using EcommerceApp.Dtos;
using EcommerceApp.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly appDbContext _context;
        public UserController(appDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getUser(int id)
        {
            var user = await _context.userTable.FindAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> UserLogin(userLoginDto user69)
        {
            var user = await _context.userTable.Where(ol => ol.Email == user69.email && ol.Password == user69.password).ToListAsync();
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]

        public async Task<IActionResult> addProducts(userDto addUser)
        {
            if (addUser != null)
            {
                var user = new User
                {
                    Name = addUser.Name,
                    Email = addUser.Email,
                    Phone = addUser.Phone,
                    Password = addUser.Password
                };

                await _context.userTable.AddAsync(user);
                _context.SaveChanges();
                return Ok(user);
            }
            return NotFound();
        }

    }
}