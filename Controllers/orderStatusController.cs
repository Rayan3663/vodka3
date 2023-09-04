using EcommerceApp.data;
using EcommerceApp.Dtos;
using EcommerceApp.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class orderStatusController : Controller
    {

        private readonly appDbContext _context;

        public orderStatusController(appDbContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<IActionResult> addStatus(statusDto addStatus)
        {
            if(addStatus != null)
            {
                var status = new OrderStatus()
                {
                    Status = addStatus.name
                };

                await _context.statusTable.AddAsync(status);
                _context.SaveChanges();
                return Ok(status);

            }
            return NotFound();
        }
    }
}
