using DiyorMarketApi.Models;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarketApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }
  
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            _logger.LogInformation("getting all products");
            return ProductsService.GetProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {

            _logger.LogInformation($"Getting product with id: {id}");
            var product = ProductsService.GetProduct(id);
            
            if (product is null)
            {
                _logger.LogError($"Product with id: {id} not found.");
                return NotFound($"Product with id: {id} does not exist.");
            }

            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            ProductsService.Create(product);
        }

        [HttpPatch("{id}")]
        public ActionResult Pacht(int id,JsonPatchDocument<Product> jsonPatch) 
        {
            var products = ProductsService.GetProduct(id);
            if(products is null)
            {
                return NotFound();
            }

            var productPatch = new Product()
            {
                Name = products.Name,
                Price= products.Price,
                CategoryId= products.CategoryId,
            };
            jsonPatch.ApplyTo(productPatch, ModelState);

            products.Name=productPatch.Name;
            products.Price=productPatch.Price;
            productPatch.CategoryId=products.CategoryId;

            return Ok(products);
        }


        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product productToUpdate)
        {
            ProductsService.Update(productToUpdate);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductsService.Delete(id);
        }
    }
}
