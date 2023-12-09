using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Repositories;
using DiyorMarket.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DiyorMarket.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IMapper mapper, ICommonRepository repository, ILogger<CategoryService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public  IEnumerable<CategoryDto>  GetCategories()
        {
            try
            {
                var categories = _repository.Category.FindAll();
                var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

                return categoryDtos;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Database error fetching categories", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching categories", ex);
                throw;
            }
        }

        public CategoryDto GetCategoryById(int id)
        {
            try
            {
                var category = _repository.Category.FindById(id);
                var categoryDto = _mapper.Map<CategoryDto>(category);

                return categoryDto;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Database error fetching category with id: {id}.", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching category with id: {id}.", ex);
                throw;
            }
        }

        public CategoryDto CreateCategory(CategoryForCreateDto categoryToCreate)
        {
            try
            {
                var categoryEntity = _mapper.Map<Category>(categoryToCreate);

                var createdEntity = _repository.Category.Create(categoryEntity);
                _repository.SaveChanges();

                var categoryDto = _mapper.Map<CategoryDto>(createdEntity);

                return categoryDto;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Database error creating new category", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating new category", ex);
                throw;
            }
        }

        public void UpdateCategory(CategoryForUpdateDto categoryToUpdate)
        {
            try
            {
                var categoryEntity = _mapper.Map<Category>(categoryToUpdate);

                _repository.Category.Update(categoryEntity);
                 _repository.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Database error updating category with id: {categoryToUpdate.Id}.", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating category with id: {categoryToUpdate.Id}", ex);
                throw;
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                _repository.Category.Delete(id);
                _repository.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Database error deleting category with id: {id}", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting category with id: {id}", ex);
                throw;
            }
        }
    }
}