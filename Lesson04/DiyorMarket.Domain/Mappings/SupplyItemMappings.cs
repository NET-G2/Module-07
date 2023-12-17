using AutoMapper;
using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.DTOs.SupplyItem;
using DiyorMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.Mappings
{
    public class SupplyItemMappings : Profile
    {
        public SupplyItemMappings() 
        {
            CreateMap<SupplyItem, SupplyItemDTOs>();
            CreateMap<SupplyItemDTOs, SupplyItem>();
            CreateMap<SupplyItemForCreateDTOs, SupplyItem>();
            CreateMap<SupplyItemForUpdateDTOs, SupplyItem>();
        }
    }
}
