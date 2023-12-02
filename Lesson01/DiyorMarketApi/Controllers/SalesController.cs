using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarketApi.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        // GET: api/<SalesController>
        [HttpGet]
        public IEnumerable<Sale> Get()
        {
            return SalesService.GetSales();
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public Sale Get(int id)
        {
            return SalesService.GetSale(id);
        }

        // POST api/<SalesController>
        [HttpPost]
        public void Post([FromBody] Sale sale)
        {
            SalesService.Create(sale);
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Sale sale)
        {
            SalesService.Update(sale);
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SalesService.Delete(id);
        }
    }
}
