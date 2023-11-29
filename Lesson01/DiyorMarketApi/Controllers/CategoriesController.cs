using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarketApi.Controllers
{
    [Route("api/categoriesD")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET: api/<CategoriesController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return CategoriesService.GetCategories();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var category = CategoriesService.GetCategory(id);

            if (category is null)
            {
                return NotFound($"Category with id: {id} does not exist.");
            }

            return category;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] Category category )
        {
            CategoriesService.Create(category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category categoryToUpdate)
        {
             CategoriesService.Update(categoryToUpdate);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoriesService.Delete(id);
        }
    }
}
