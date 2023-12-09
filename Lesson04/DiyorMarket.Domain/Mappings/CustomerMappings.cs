using AutoMapper;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Entities;

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
