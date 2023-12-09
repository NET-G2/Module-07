using Bogus;
using DiyorMarketApi.Models;

namespace DiyorMarketApi.Services
{
    public class OrdersService
    {
        public static Random _random = new Random();

        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                CustomerId = 1,
                OrderDate = DateTime.Now.AddDays(_random.NextInt64()),
                TotalPrice = _random.NextInt64(),
            },
            new Order
            {
                Id = 2,
                CustomerId = 2,
                OrderDate = DateTime.Now.AddDays(_random.NextInt64()),
                TotalPrice = _random.NextInt64(),
            },
            new Order
            {
                Id = 3,
                CustomerId = 3,
                OrderDate = DateTime.Now.AddDays(_random.NextInt64()),
                TotalPrice = _random.NextInt64(),
            }
        };
        public static List<Order> GetOrders()
            => Orders;

        public static Order? GetOrders(int id)
            => Orders.FirstOrDefault(c => c.Id == id);

        public static void Create(Order order)
            => Orders.Add(order);


        public static void Update(Order order )
        {
            var orderToUpdate = Orders.FirstOrDefault(x => x.Id == order.Id);
            if (orderToUpdate is null)
            {
                return;
            }
            orderToUpdate.TotalPrice = order.TotalPrice;
            orderToUpdate.CustomerId = order.CustomerId;
            orderToUpdate.OrderDate = DateTime.Now;
        }
        public static void Delete(int id)
        {
            var order = Orders.FirstOrDefault(x => x.Id == id);
            if (order is not null)
            {
                Orders.Remove(order);
            }
        }
    }
}
