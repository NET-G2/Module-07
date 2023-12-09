using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Interfaces.Services;
using DiyorMarketApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiyorMarketApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetCategoriesAsync();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"There was error returning categories. {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);

                if (category is null)
                {
                    return NotFound($"Category with id: {id} does not exist.");
                }

                return Ok(category);
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"Product with id: {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"There was error getting category with id: {id}. {ex.Message}");
            }
        }

        [HttpGet("{id}/products")]
        public ActionResult<ProductDto> GetProductsByCategoryId(int id)
        {
            try
            {
                var products = ProductsService.GetProducts();

                var filteredProducts = products.Where(x => x.CategoryId == id).ToList();

                return Ok(filteredProducts);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound($"Product with id: {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"There was an error returning products for category: {id}. {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post(CategoryForCreateDto category)
        {
            try
            {
                var createdCategory = await _categoryService.CreateCategoryAsync(category);

                return Created("", createdCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"There was an error creating new category. {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoryAsync([FromRoute] int id, [FromBody] CategoryForUpdateDto category)
        {
            if (id != category.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {category.Id}.");
            }

            try
            {
                await _categoryService.UpdateCategoryAsync(category);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500,
                    $"There was an error updating category with id: {id}. {ex.Message}");

            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);

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
