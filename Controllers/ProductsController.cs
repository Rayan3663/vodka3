using AutoMapper;
using EcommerceApp.data;
using EcommerceApp.Dtos;
using EcommerceApp.Mappers;
using EcommerceApp.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly appDbContext _context;
        private readonly UrlShortenerService _urlShortener;
        private readonly IMapper _mapper;
        public ProductsController(appDbContext context, UrlShortenerService urlShortener, IMapper mapper)
        {
            _context = context;
            _urlShortener = urlShortener;
            _mapper = mapper;

        }


        [HttpGet]
        public async Task<IActionResult> getProducts()
        {
            return Ok(await _context.productsTable.ToListAsync());
        }


        [HttpPost]

        public async Task<IActionResult> addProducts(productDto addProduct)
        {
            if (addProduct != null)
            {
                //string shortUrl = await _urlShortener.ShortenUrlAsync(addProduct.url);
                //var product = new Products
                //{
                //    itemName = addProduct.itemName,
                //    Cost = addProduct.Cost,
                //    url = addProduct.url,
                //    description = addProduct.description

                //};

                var product = _mapper.Map<Products>(addProduct);
                await _context.productsTable.AddAsync(product);
                _context.SaveChanges();
                return Ok(product);
            }
            return NotFound();
        }



    }
}
