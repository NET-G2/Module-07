using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiyorMarketApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return CategoriesService.GetCategories();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return CategoriesService.GetCategory(id);
        }

        [HttpGet("{id}/products")]
        public ActionResult<List<Product>> GetProductByCategory(int id)
        {
            var products = ProductsService.GetProducts();

            var filtrProducts = products.Where(x => x.CategoryId == id).ToList();

            return filtrProducts;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            CategoriesService.Create(category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category )
        {
            CategoriesService.Update(category);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoriesService.Delete(id);
        }
    }
}
