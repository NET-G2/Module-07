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
            try
            {
                _logger.LogInformation($" Getting all products ");
                return ProductsService.GetProducts();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(" Does not products not found... ");
                return Ok($"Not found exception..{ex.Message}");
            }
        }


        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = ProductsService.GetProduct(id);
            
            if (product is null)
            {
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

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product productToUpdate)
        {
            ProductsService.Update(productToUpdate);
        }

        [HttpPatch("{id}")]
        public ActionResult PartiallyUpdateProduct(int id, JsonPatchDocument<Product> jsonPatch)
        {
            var product = ProductsService.GetProduct(id);

            if(product is null)
            {
                return NotFound("Product with id : {id} does not exist..");
            }

            var productToPatch = new Product()
            {
                Id = product.Id,
               Name = product.Name,
               Price = product.Price,
               CategoryId = product.CategoryId
            };

            jsonPatch.ApplyTo(productToPatch, ModelState);

            product.Id = productToPatch.Id;
            product.Name = productToPatch.Name;
            product.Price = productToPatch.Price;
            product.CategoryId = productToPatch.CategoryId;

            return Ok(productToPatch);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductsService.Delete(id);
        }
    }
}
