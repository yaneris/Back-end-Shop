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
    public class OrdersController : ControllerBase
    {
        private readonly Context _context;

        public OrdersController(Context context)
        {
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<OrderDTO>> GetOrder()
        {
            var order = from orders in _context.orders 
                join product in _context.products on orders.product_id equals product.product_id
                select new OrderDTO()
                {
                    customer_id = orders.customer_id,
                    order_id = orders.order_id,
                    product_id = product.product_id,
                    price = product.price
                };

            return Ok(order);
        }
        
        [HttpGet("{id}")]
        public ActionResult<OrderDTO> GetOrder_byId(int id)
        {
            var order = from orders in _context.orders
                join product in _context.products on orders.product_id equals product.product_id
                join customer in _context.customers on orders.customer_id equals customer.id
                select new OrderDTO
                {
                    customer_id = customer.id,
                    order_id = orders.order_id,
                    product_id = product.product_id,
                    price = product.price
                };

            var order_by_id = order.ToList().Find(x => x.order_id == id);

            if (order_by_id == null)
            {
                return NotFound();
            }
            return order_by_id;
        }
        
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders order)
        {
            _context.orders.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrder", new { id = order.order_id }, order);
        }
    }
}