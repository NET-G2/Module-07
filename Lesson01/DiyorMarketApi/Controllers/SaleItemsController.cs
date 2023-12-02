using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarketApi.Controllers
{
    [Route("api/saleItems")]
    [ApiController]
    public class SaleItemsController : ControllerBase
    {
        // GET: api/<SaleItemsController>
        [HttpGet]
        public IEnumerable<SaleItem> Get()
        {
            return SaleItemsService.GetSaleItems();
        }

        // GET api/<SaleItemsController>/5
        [HttpGet("{id}")]
        public SaleItem Get(int id)
        {
            return SaleItemsService.GetSaleitem(id);
        }

        // POST api/<SaleItemsController>
        [HttpPost]
        public void Post([FromBody] SaleItem saleItem)
        {
            SaleItemsService.Create(saleItem);
        }

        // PUT api/<SaleItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SaleItem saleItem)
        {
            SaleItemsService.Update(saleItem);
        }

        // DELETE api/<SaleItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SaleItemsService.Delete(id);
        }
    }
}
