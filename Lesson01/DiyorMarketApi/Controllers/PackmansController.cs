using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarketApi.Controllers
{
    [Route("api/packmans")]
    [ApiController]
    public class PackmansController : ControllerBase
    {
        // GET: api/<PackmansController>
        [HttpGet]
        public IEnumerable<Packman> Get()
        {
            return PackmansService.GetPackmans();
        }

        // GET api/<PackmansController>/5
        [HttpGet("{id}")]
        public Packman Get(int id)
        {
            return PackmansService.GetPackmen(id);
        }

        // POST api/<PackmansController>
        [HttpPost]
        public void Post([FromBody] Packman value)
        {
            PackmansService.Create(value);
        }

        // PUT api/<PackmansController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Packman value)
        {
            PackmansService.Update(value);
        }

        // DELETE api/<PackmansController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PackmansService.Delete(id);
        }
    }
}
