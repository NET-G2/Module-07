using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Repositories;
using DiyorMarket.Domain.Interfaces.Services;
using Serilog;
using System.Data.Common;

namespace DiyorMarket.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger _logger;

        public CategoryService(IMapper mapper, ICommonRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            try
            {
                var categories = _repository.Category.FindAll();

                var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

                return categoryDtos;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between Category and CategoryDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error("Database error occured while fetching categories.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error("Something went wrong while fetching categories.", ex.Message);
                throw;
            }
        }

        public CategoryDto? GetCategoryById(int id)
        {
            try
            {
                var category = _repository.Category.FindById(id);

                var categoryDto = _mapper.Map<CategoryDto>(category);

                return categoryDto;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between Category and CategoryDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error($"Database error occured while fetching category with id: {id}.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong while fetching category with id: {id}.", ex.Message);
                throw;
            }
        }

        public CategoryDto CreateCategory(CategoryForCreateDto categoryToCreate)
        {
            try
            {
                var categoryEntity = _mapper.Map<Category>(categoryToCreate);
                
                var createdCategory = _repository.Category.Create(categoryEntity);
                _repository.SaveChanges();

                var categoryDto = _mapper.Map<CategoryDto>(createdCategory);

                return categoryDto;
            }
            catch(AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between Category and CategoryDto", ex.Message);
                throw;
            }
            catch(DbException ex)
            {
                _logger.Error("Database error occured while creating new category.", ex.Message);
                throw;
            }
            catch(Exception ex)
            {
                _logger.Error("Something went wrong while creating new category.", ex.Message);
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
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between Category and CategoryDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error("Database error occured while updating category.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error("Something went wrong while updating category.", ex.Message);
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
            catch (DbException ex)
            {
                _logger.Error($"Database error occured while deleting category with id: {id}.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong while deleting category with id: {id}.", ex.Message);
                throw;
            }
        }
    }
}
