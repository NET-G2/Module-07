using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarketApi.Controllers
{
    [Route("api/orderItems")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        // GET: api/<SaleItemsController>
        [HttpGet]
        public IEnumerable<OrderItem> Get()
        {
            return OrderItemsService.GetSaleItems();
        }

        // GET api/<SaleItemsController>/5
        [HttpGet("{id}")]
        public OrderItem Get(int id)
        {
            return OrderItemsService.GetSaleitem(id);
        }

        // POST api/<SaleItemsController>
        [HttpPost]
        public void Post([FromBody] OrderItem saleItem)
        {
            OrderItemsService.Create(saleItem);
        }

        // PUT api/<SaleItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderItem saleItem)
        {
            OrderItemsService.Update(saleItem);
        }

        // DELETE api/<SaleItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OrderItemsService.Delete(id);
        }
    }
}
