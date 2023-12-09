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
                Name = "Olim",
                Age = 35,
                Number="99992001",
            },
            new Customer
            {
                Id = 2,
                Name = "Aziz",
                Age = 19,
                Number="99777701",
            },
            new Customer
            {
                Id = 3,
                Name = "Karim",
                Age = 91,
                Number="91111101",
            },
        };
        public static List<Customer> GetCustomers()
            => Customers;

        public static Customer? GetCustomer(int id)
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
            customerToUpdate.Name = customer.Name;
            customerToUpdate.Age = customer.Age;
            customerToUpdate.Number = customer.Number;    
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
