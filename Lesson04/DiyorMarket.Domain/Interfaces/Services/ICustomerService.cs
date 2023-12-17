using DiyorMarket.Domain.DTOs.Customer;

namespace DiyorMarket.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDtOs> GetCustomers();
        CustomerDtOs? GetCustomerById(int id);
        CustomerDtOs CreateCustomer(CustomerForCereateDTOs customerToCreate);
        void UpdateCustomer(CustomerForCereateDTOs customerToUpdate);
        void DeleteCustomer(int id);
    }
}
