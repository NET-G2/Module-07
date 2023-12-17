using AutoMapper;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.Mappings
{
    public class SaleMappings : Profile
    {
        public SaleMappings() 
        {
            CreateMap<Sale, SaleDTOs>();
            CreateMap<SaleDTOs, Sale>();
            CreateMap<SaleForCreateDTOs, Sale>();
            CreateMap<SaleForUpdateDTOs, Sale>();
        }
    }
}
