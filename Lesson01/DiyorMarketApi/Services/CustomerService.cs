using DiyorMarketApi.Models;

namespace DiyorMarketApi.Services
{
    public class CustomerService
    {
        private static List<Customer> Custosmers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                FirstName = "Avazbek",
                LastName = "Baxodirov",
                PhoneNumber = "1234567890"
            },
            new Customer
            {
                Id = 2,
                FirstName = "Asilbek",
                LastName = "Alijonov",
                PhoneNumber = "15154144"
            },
            new Customer
            {
                Id = 3,
                FirstName = "Anvar",
                LastName = "Abdumuhtorov",
                PhoneNumber = "55555555555"
            },
            new Customer
            {
                Id = 4,
                FirstName = "Muhammadali",
                LastName = "Sharifov",
                PhoneNumber = "0000000000000"
            },
            new Customer
            {
                Id = 5,
                FirstName = "Tohir",
                LastName = "Nazarov",
                PhoneNumber = "4444444444"
            },
            new Customer
            {
                Id = 6,
                FirstName = "Javohir",
                LastName = "Qosimov",
                PhoneNumber = "777777777777"
            },
            new Customer
            {
                Id = 7,
                FirstName = "Diyor",
                LastName = "Qurbonov",
                PhoneNumber = "111111111111"
            },
            new Customer
            {
                Id = 8,
                FirstName = "Nozim",
                LastName = "Tursunov",
                PhoneNumber = "3333333333333"
            },
        };

        public static List<Customer> GetCustomers()
            => Custosmers;

        public static Customer? GetCustomer(int id)
            => Custosmers.FirstOrDefault(x => x.Id == id);

        public static void Create(Customer product)
            => Custosmers.Add(product);

        public static void Update(Customer customer)
        {
            var customerToUpdate = Custosmers.FirstOrDefault(x => x.Id == customer.Id);

            if (customerToUpdate is null)
            {
                return;
            }

            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.PhoneNumber = customer.PhoneNumber;
        }

        public static void Delete(int id)
        {
            var customer = Custosmers.FirstOrDefault(x => x.Id == id);

            if (customer is not null)
            {
                Custosmers.Remove(customer);
            }
        }
    }
}
