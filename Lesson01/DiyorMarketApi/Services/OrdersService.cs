using DiyorMarketApi.Models;

namespace DiyorMarketApi.Services
{
    public class OrdersService
    {
        private static List<Order> Sales = new List<Order>
        {

            new Order
            {
                Id = 1,
                OrderDate = DateTime.Now.AddHours(-0.5),
                CustomerId = 1
            },
            new Order
            {
                Id = 2,
                OrderDate = DateTime.Now.AddHours(-1),
                CustomerId = 4
            },
            new Order
            {
                Id = 3,
                OrderDate = DateTime.Now.AddHours(-2),
                CustomerId = 3
            },
            new Order
            {
                Id = 4,
                OrderDate = DateTime.Now.AddHours(-3),
                CustomerId = 2
            },
            new Order
            {
                Id = 5,
                OrderDate = DateTime.Now.AddHours(-4),
                CustomerId = 1
            },
            new Order
            {
                Id = 6,
                OrderDate = DateTime.Now.AddHours(-3.5),
                CustomerId = 3
            },
            new Order
            {
                Id = 7,
                OrderDate = DateTime.Now.AddHours(-1.5),
                CustomerId = 2
            },
            new Order
            {
                Id = 8,
                OrderDate = DateTime.Now.AddHours(-5.5),
                CustomerId = 8
            },
        };

        public static List<Order> GetSales()
            => Sales;

        public static Order? GetSale(int id)
            => Sales.FirstOrDefault(x => x.Id == id);

        public static void Create(Order sale)
            => Sales.Add(sale);

        public static void Update(Order sale)
        {
            var saleToUpdate = Sales.FirstOrDefault(x => x.Id == sale.Id);

            if (saleToUpdate is null)
            {
                return;
            }

            saleToUpdate.OrderDate = sale.OrderDate;
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
