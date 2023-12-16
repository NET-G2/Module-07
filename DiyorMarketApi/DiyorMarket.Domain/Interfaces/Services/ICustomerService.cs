using DiyorMarket.Domain.DTOs.Customer;

namespace DiyorMarket.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetCustomers();
        CustomerDto? GetCustomerById(int id);
        CustomerDto CreateCustomer(CustomerForCreateDto customerToCreate);
        void UpdateCustomer(CustomerForUpdateDto customerToUpdate);
        void DeleteCustomer(int id);
    }
}
