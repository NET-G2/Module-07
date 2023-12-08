using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.Mappings
{
    public class CustomerMappings : Profile
    {
        public CustomerMappings() 
        {
            CreateMap<Customer, CustomerDtOs>();
            CreateMap<CustomerDtOs, Customer>();
            CreateMap<CustomerForCereateDTOs, Customer>();
            CreateMap<CustomerForUpdateDTOs, Customer>();
        }
    }
}
