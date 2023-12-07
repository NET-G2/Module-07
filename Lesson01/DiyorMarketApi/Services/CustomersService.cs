using DiyorMarketApi.Models;

namespace DiyorMarketApi.Services
{
    public class CustomersService
    {
        public static List<Customer> Customers = new List<Customer>
        {

            new Customer
            {
            Id = 1,
            FullName = "Muhammadali",
            Address = "Tashkent",
            PhoneNumber = "+998949335203",
            Email = "sharifovmuhammadali571@gmail.com"
            }
        };

        static CustomersService()
        {
            // Add 10 fake customers manually
            for (int i = 2; i <= 11; i++)
            {
                Customers.Add(new Customer
                {
                    Id = i,
                    FullName = $"FakeCustomer{i}",
                    Address = $"Address{i}",
                    PhoneNumber = $"+9989{i}012345",
                    Email = $"fakecustomer{i}@example.com"
                });
            }
        }


        public static List<Customer> GetCustomers()
             => Customers;

        public static Customer? GetCustomers(int id)
            => Customers.FirstOrDefault(x => x.Id == id);


        public static void Create(Customer customer)
            => Customers.Add(customer);

        public static void Update(Customer customer)
        {
            var customerToUpdate = Customers.FirstOrDefault(x => x.Id == customer.Id);

            if (customerToUpdate is null)
            {
                return;
            }

            customerToUpdate.FullName = customer.FullName;
            customerToUpdate.Address = customer.Address;
            customerToUpdate.PhoneNumber = customer.PhoneNumber;
            customerToUpdate.Email = customer.Email;
        }

        public static void Delete(int id)
        {
            var customer = Customers.FirstOrDefault(x => x.Id == id);

            if (customer is not null)
            {
                Customers.Remove(customer);
            }
        }


    }
}
