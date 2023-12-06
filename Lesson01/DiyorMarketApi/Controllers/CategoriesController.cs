using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.JsonPatch;
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
        public void Put(int id, [FromBody] Category category)
        {
            CategoriesService.Update(category);
        }

        [HttpPatch("{id}")]
        //public ActionResult PartiallyUpdateCategory(
        //    int id,
        //    JsonPatchDocument<Category> jsonPatch)
        //{
        //    var category = CategoriesService.GetCategory(id);

        //    if (category is null)
        //    {
        //        return NotFound($"Product with id: {id} does not exist.");
        //    }
        
        //    var productToPatch = new Product()
        //    {
        //        Name = category.Name,
        //        Price = category.Price,
        //        CategoryId = category.CategoryId,
        //    };

        //    jsonPatch.ApplyTo(categoryToPatch, ModelState);

        //    category.Name = productToPatch.Name;
        //    category.Price = productToPatch.Price;
        //    category.CategoryId = productToPatch.CategoryId;

        //    return NoContent();
        //}

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoriesService.Delete(id);
        }
    }
}
