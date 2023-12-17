using AutoMapper;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.DTOs.SaleItem;
using DiyorMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.Mappings
{
    public class SaleItemMappings : Profile
    {
        public SaleItemMappings() 
        {
            CreateMap<SaleItem, SaleItemDTOs>();
            CreateMap<SaleItemDTOs, SaleItem>();
            CreateMap<SaleItemForCreateDTOs, SaleItem>();
            CreateMap<SaleItemForUpdateDTOs, SaleItem>();
        }
    }
}
