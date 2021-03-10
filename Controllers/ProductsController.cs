using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.DTO;
using Shop.Models;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly Context _context;

        public ProductsController(Context context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProduct()
        {
            return await _context.products.ToListAsync();
        }
        
        [HttpPost]
        public async Task<ActionResult<AddProduct>> Add_Product(AddProduct productDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Products()
            {
                product_id = productDTO.product_id,
                price = productDTO.price,
                product_name = productDTO.product_name
            };
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
            

            return CreatedAtAction("GetProduct", new { id = product.product_id}, productDTO);
        }
    }
}