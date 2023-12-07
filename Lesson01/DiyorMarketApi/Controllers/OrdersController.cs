using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarketApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
            =>OrdersService.GetOrders();

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
         public static ActionResult<Order>Get(int id)
            =>OrdersService.GetOrder(id);
        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] Order order)
        =>OrdersService.Create(order);

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order order)
        =>OrdersService.Update(order);
        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        =>OrdersService.Delete(id);
    }
}
