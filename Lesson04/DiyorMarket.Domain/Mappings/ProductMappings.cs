using AutoMapper;
using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductForCreateDTOs, Product>();
            CreateMap<ProductForUpdateDTOs, Product>();
        }
    }
}
