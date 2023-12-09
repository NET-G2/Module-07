using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarketApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET: api/<CategoriesController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            try
            {
                var categories = CategoriesService.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"There was error returning categories .{ex.Message}");
            }
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            try
            {
                var category = CategoriesService.GetCategory(id);

                if (category is null)
                {
                    return NotFound($"Category with id: {id} does not exist.");
                }

                return Ok(category);
            }
            catch(Exception ex)
            {
                return StatusCode(500,
                    $"There was error getting category with id:{id}. {ex.Message}");
            }
            
        }

        [HttpGet("{id}/products")]
        public ActionResult<Product> GetProducts(int id)
        {
            try
            {
                var products = ProductsService.GetProducts();
                var filteredProduct = products.Where(x => x.CategoryId == id).ToList();
                return Ok(filteredProduct);
            }catch(Exception ex)
            {
                return StatusCode(500,
                    $"There was an error returning product for category: {id}. {ex.Message}");
            }
        }

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

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoriesService.Delete(id);
        }
    }
}
