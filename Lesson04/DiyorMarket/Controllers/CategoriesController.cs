using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using DiyorMarket.Services.ServicesForEntities;

namespace DiyorMarketApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<CategoryDto>> Get()
        {
            try
            {
                var categories = _categoryService.GetCategories();

                return Ok(categories);
            }
            catch(Exception ex)
            {
                return StatusCode(500,
                    $"There was error returning categories. {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult<CategoryDto> Get(int id)
        {
            try
            {
                var category = _categoryService.GetCategoryById(id);

                if (category is null)
                {
                    return NotFound($"Category with id: {id} does not exist.");
                }

                return Ok(category);
            }
            catch(Exception ex)
            {
                return StatusCode(500,
                    $"There was error getting category with id: {id}. {ex.Message}");
            }
        }

        //[HttpGet("{id}/products")]
        //public ActionResult<ProductDto> GetProductsByCategoryId(int id)
        //{
        //    try
        //    {
        //        var products = _categoryService.G();

        //        var filteredProducts = products.Where(x => x.CategoryId == id).ToList();

        //        return Ok(filteredProducts);
        //    }
        //    catch(Exception ex)
        //    {
        //        return StatusCode(500,
        //            $"There was an error returning products for category: {id}. {ex.Message}");
        //    }
        //}

        [HttpPost]
        public ActionResult Post([FromBody] CategoryForCreateDto category)
        {
            try
            {
               _categoryService.CreateCategory(category);

                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return StatusCode(500, 
                    $"There was an error creating new category. {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CategoryForUpdateDto category)
        {
            if (id != category.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {category.Id}.");
            }

            try
            {
                _categoryService.UpdateCategory(category);

                return NoContent();
            }
            catch(Exception ex)
            {

                return StatusCode(500, 
                    $"There was an error updating category with id: {id}. {ex.Message}");

            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, 
                    $"There was an error deleting category with id: {id}. {ex.Message}");
            }
        }
    }
}
