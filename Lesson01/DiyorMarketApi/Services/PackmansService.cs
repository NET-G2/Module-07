using DiyorMarketApi.Models;

namespace DiyorMarketApi.Services
{
    public class PackmansService
    {
        private static List<Packman> Packmen = new List<Packman>
        {
            new Packman
            {
                Id = 1,
                FirstName = "Avazbek",
                LastName = "Baxodirov",
                PhoneNumber = "1234567890",
                Company = "Microsoft"
            },
            new Packman
            {
                Id = 2,
                FirstName = "Asilbek",
                LastName = "Alijonov",
                PhoneNumber = "15154144",
                Company = "ACER"
            },
            new Packman
            {
                Id = 3,
                FirstName = "Anvar",
                LastName = "Abdumuhtorov",
                PhoneNumber = "55555555555",
                Company = "HP"
            },
            new Packman
            {
                Id = 4,
                FirstName = "Muhammadali",
                LastName = "Sharifov",
                PhoneNumber = "0000000000000",
                Company = "Mi"
            },
            new Packman
            {
                Id = 5,
                FirstName = "Tohir",
                LastName = "Nazarov",
                PhoneNumber = "4444444444",
                Company = "Samsung"
            },
            new Packman
            {
                Id = 6,
                FirstName = "Javohir",
                LastName = "Qosimov",
                PhoneNumber = "777777777777",
                Company = "Apple"
            },
            new Packman
            {
                Id = 7,
                FirstName = "Diyor",
                LastName = "Qurbonov",
                PhoneNumber = "111111111111",
                Company = "Google"
            },
            new Packman
            {
                Id = 8,
                FirstName = "Nozim",
                LastName = "Tursunov",
                PhoneNumber = "3333333333333",
                Company = "Amazon"
            },
        };

        public static List<Packman> GetPackmans()
            => Packmen;

        public static Packman? GetPackmen(int id)
            => Packmen.FirstOrDefault(x => x.Id == id);

        public static void Create(Packman product)
            => Packmen.Add(product);

        public static void Update(Packman customer)
        {
            var customerToUpdate = Packmen.FirstOrDefault(x => x.Id == customer.Id);

            if (customerToUpdate is null)
            {
                return;
            }

            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.PhoneNumber = customer.PhoneNumber;
            customerToUpdate.Company = customer.Company;
        }

        public static void Delete(int id)
        {
            var customer = Packmen.FirstOrDefault(x => x.Id == id);

            if (customer is not null)
            {
                Packmen.Remove(customer);
            }
        }
    }
}
