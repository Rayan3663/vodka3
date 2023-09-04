using AutoMapper;
using EcommerceApp.data;
using EcommerceApp.Dtos;
using EcommerceApp.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EcommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : Controller
    {

        private readonly appDbContext _context;
        private readonly IMapper _mapper;
        public SellerController(appDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SellerLogin(sellerLoginDto seller69)
        {
            var user = await _context.sellerTable.Where(ol => ol.Email == seller69.email && ol.Password == seller69.password).ToListAsync();
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddSeller(sellerDto sellerBody)
        {
            //var seller1 = _mapper.Map<Seller>(sellerBody);
            if (sellerBody != null)
            {
                var seller1 = new Seller
                {
                    Email = sellerBody.Email,
                    Password = sellerBody.Password,
                    Name = sellerBody.Name,
                    Phone = sellerBody.Phone
                };

                await _context.sellerTable.AddAsync(seller1);
                await _context.SaveChangesAsync();
                return Ok(seller1);
            }
            return BadRequest();
        }
    }
}
