using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarketApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OredrsController : ControllerBase
    {
        // GET: api/<SalesController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return OrdersService.GetSales();
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return OrdersService.GetSale(id);
        }

        // POST api/<SalesController>
        [HttpPost]
        public void Post([FromBody] Order sale)
        {
            OrdersService.Create(sale);
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order sale)
        {
            OrdersService.Update(sale);
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OrdersService.Delete(id);
        }
    }
}
