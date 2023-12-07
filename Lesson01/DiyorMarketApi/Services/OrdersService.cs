using DiyorMarketApi.Models;

namespace DiyorMarketApi.Services
{
    public class OrdersService
    {
        private static List<Order> Orders = new List<Order>
        {
          new Order
          {
              Id = 1,
              OrderDate = DateTime.Now,
              CustomerId = 1,
          },
           new Order
           {
              Id = 2,
              OrderDate = DateTime.UtcNow,
              CustomerId = 2,
           },
           new Order
           {
              Id = 3,
              OrderDate = DateTime.MinValue,
              CustomerId = 4,
           },
           new Order
           {
              Id = 4,
              OrderDate = DateTime.MaxValue,
              CustomerId = 5
           }
        };

        public static List<Order> GetOrders()
            => Orders;
        public static Order? GetOrder(int id) 
            =>Orders.FirstOrDefault(x=>x.Id == id); 
        public static void Create(Order order)
            =>Orders.Add(order);
        public static void Update(Order order)
        {
            var orderToUpdate=Orders.FirstOrDefault(x=>x.Id==order.Id);
            if (orderToUpdate is null)
            {
                return;
            }

            orderToUpdate.Id= order.Id;
            orderToUpdate.OrderDate= order.OrderDate;
            orderToUpdate.CustomerId= order.CustomerId;
        }
        public static void Delete(int id)
        {
            var order = Orders.FirstOrDefault(x => x.Id == id);
            if (order != null) 
            {
                Orders.Remove(order);
            }
        }

        
    }
}
