using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
