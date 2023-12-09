using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        // GET: api/<OrderItemsController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderItems>> Get()
        {
            return OrderItemsService.GetOrderItems();
        }

        // GET api/<OrderItemsController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderItems> Get(int id)
        {
            var orderitem = OrdersService.GetOrders(id);
            if (orderitem is null)
            {
                return NotFound($"OrderItems with id: {id} does not exist.");
            }

            return Ok(orderitem);
        }

        // POST api/<OrderItemsController>
        [HttpPost]
        public void Post([FromBody] OrderItems orderItems)
        {
            OrderItemsService.Create(orderItems);
        }

        // PUT api/<OrderItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderItems orderItems)
        {
            OrderItemsService.Update(orderItems);
        }

        // DELETE api/<OrderItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OrderItemsService.Delete(id);
        }
    }
}
