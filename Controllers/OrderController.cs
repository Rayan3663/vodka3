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
    public class OrderController : Controller
    {

        private readonly appDbContext _context;
        private readonly IMapper _mapper;
        public OrderController(appDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> AddOrder([FromRoute] int id, orderDto orderBody)
        {
            var user1 = await _context.userTable.FindAsync(id);
            if (user1 != null) {
                var orderCont = new List<Order>();
                foreach (var i in orderBody.Products)
                {
                    Order order1 = _mapper.Map<Order>(orderBody);
                    order1.user = user1;

                    var product1 = await _context.productsTable.FirstOrDefaultAsync(pro => pro.itemName == i.itemName);
                    order1.Products = new List<Products> { product1 };
                    orderCont.Add(order1); 
                }
            

                user1.Order = orderCont;
                await _context.SaveChangesAsync();
                return Ok(user1);
            }



            return NotFound();
        }
    }
}
