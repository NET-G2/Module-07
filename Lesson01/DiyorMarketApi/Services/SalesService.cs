using DiyorMarketApi.Models;

namespace DiyorMarketApi.Services
{
    public class SalesService
    {
        private static List<Sale> Sales = new List<Sale>
        {

            new Sale
            {
                Id = 1,
                SaleDate = DateTime.Now.AddHours(-0.5),
                CustomerId = 1
            },
            new Sale
            {
                Id = 2,
                SaleDate = DateTime.Now.AddHours(-1),
                CustomerId = 4
            },
            new Sale
            {
                Id = 3,
                SaleDate = DateTime.Now.AddHours(-2),
                CustomerId = 3
            },
            new Sale
            {
                Id = 4,
                SaleDate = DateTime.Now.AddHours(-3),
                CustomerId = 2
            },
            new Sale
            {
                Id = 5,
                SaleDate = DateTime.Now.AddHours(-4),
                CustomerId = 1
            },
            new Sale
            {
                Id = 6,
                SaleDate = DateTime.Now.AddHours(-3.5),
                CustomerId = 3
            },
            new Sale
            {
                Id = 7,
                SaleDate = DateTime.Now.AddHours(-1.5),
                CustomerId = 2
            },
            new Sale
            {
                Id = 8,
                SaleDate = DateTime.Now.AddHours(-5.5),
                CustomerId = 8
            },
        };

        public static List<Sale> GetSales()
            => Sales;

        public static Sale? GetSale(int id)
            => Sales.FirstOrDefault(x => x.Id == id);

        public static void Create(Sale sale)
            => Sales.Add(sale);

        public static void Update(Sale sale)
        {
            var saleToUpdate = Sales.FirstOrDefault(x => x.Id == sale.Id);

            if (saleToUpdate is null)
            {
                return;
            }

            saleToUpdate.SaleDate = sale.SaleDate;
            saleToUpdate.CustomerId = sale.CustomerId;
        }

        public static void Delete(int id)
        {
            var sales = Sales.FirstOrDefault(x => x.Id == id);

            if (sales is not null)
            {
                Sales.Remove(sales);
            }
        }
    }
}
