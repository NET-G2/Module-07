using AutoMapper;
using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Services;
using DiyorMarket.Domain.Pagniation;
using DiyorMarket.Infrastructure.Persistence;
using DiyorMarket.ResourceParameters;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace DiyorMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IMapper mapper, DiyorMarketDbContext context, ILogger<ProductService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public PaginatedList<ProductDto> GetProducts(ProductResourceParameters productResourceParameters)
        {
            var query = _context.Products.AsQueryable();

            if (productResourceParameters.CategoryId is not null)
            {
                query = query.Where(x => x.CategoryId == productResourceParameters.CategoryId);
            }

            if (!string.IsNullOrWhiteSpace(productResourceParameters.SearchString))
            {
                query = query.Where(x => x.Name.Contains(productResourceParameters.SearchString)
                || x.Description.Contains(productResourceParameters.SearchString));
            }

            if (productResourceParameters.Price is not null)
            {
                query = query.Where(x => x.Price == productResourceParameters.Price);
            }

            if (productResourceParameters.PriceLessThan is not null)
            {
                query = query.Where(x => x.Price < productResourceParameters.PriceLessThan);
            }

            if (productResourceParameters.PriceGreaterThan is not null)
            {
                query = query.Where(x => x.Price > productResourceParameters.PriceGreaterThan);
            }

            if (!string.IsNullOrEmpty(productResourceParameters.OrderBy))
            {
                query = productResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "name" => query.OrderBy(x => x.Name),
                    "namedesc" => query.OrderByDescending(x => x.Name),
                    "description" => query.OrderBy(x => x.Description),
                    "descriptiondesc" => query.OrderByDescending(x => x.Description),
                    "price" => query.OrderBy(x => x.Price),
                    "pricedesc" => query.OrderByDescending(x => x.Price),
                    "expiredate" => query.OrderBy(x => x.ExpireDate),
                    "expiredatedesc" => query.OrderByDescending(x => x.ExpireDate),
                    _ => query.OrderBy(x => x.Name),
                };
            }

            var products = query.ToPaginatedList(productResourceParameters.PageSize, productResourceParameters.PageNumber);
            // var products = query.ToList();
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return new PaginatedList<ProductDto>(productDtos, products.TotalCount, products.CurrentPage, products.PageSize);

        }

        public ProductDto? GetProductById(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == id);

                var productDto = _mapper.Map<ProductDto>(product);

                return productDto;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError($"There was an error mapping between Product and ProductDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.LogError($"Database error occured while fetching product with id: {id}.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong while fetching product with id: {id}.", ex.Message);
                throw;
            }
        }

        public ProductDto CreateProduct(ProductForCreateDto productToCreate)
        {
            try
            {
                var productEntity = _mapper.Map<Product>(productToCreate);

                _context.Products.Add(productEntity);
                _context.SaveChanges();

                var productDto = _mapper.Map<ProductDto>(productEntity);

                return productDto;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError($"There was an error mapping between Product and ProductDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.LogError("Database error occured while creating new product.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong while creating new product.", ex.Message);
                throw;
            }
        }

        public void UpdateProduct(ProductForUpdateDto productToUpdate)
        {
            try
            {
                var productEntity = _mapper.Map<Product>(productToUpdate);

                _context.Products.Update(productEntity);
                _context.SaveChanges();
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError($"There was an error mapping between Product and ProductDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.LogError("Database error occured while updating product.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong while updating product.", ex.Message);
                throw;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == id);
                if (product is not null)
                {
                    _context.Products.Remove(product);
                }
                _context.SaveChanges();
            }
            catch (DbException ex)
            {
                _logger.LogError($"Database error occured while deleting product with id: {id}.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong while deleting product with id: {id}.", ex.Message);
                throw;
            }
        }
    }
}
