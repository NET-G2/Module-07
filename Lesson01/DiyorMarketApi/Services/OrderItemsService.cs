using DiyorMarketApi.Models;

namespace DiyorMarketApi.Services
{
    public class OrderItemsService
    {
        public static List<OrderItems> OrderItems = new List<OrderItems>
        {
            new OrderItems
            {
                Id = 1,
                OrderId = 1,
                ProductId = 1,
                Quantity = 3,
            },
            new OrderItems
            {
                Id = 2,
                OrderId = 2,
                ProductId = 3,
                Quantity = 5,
            },
            new OrderItems
            {
                Id = 3,
                OrderId = 3,
                ProductId = 2,
                Quantity = 2,
            }
        };
        public static List<OrderItems> GetOrderItems()
            => OrderItems;
        public static OrderItems? GetOrderItems(int id)
            =>OrderItems.FirstOrDefault(OrderItems => OrderItems.Id == id);

        public static void Create(OrderItems orderItems) 
            =>OrderItems.Add(orderItems);

        public static void Update(OrderItems orderItems)
        {
            var order=OrderItems.FirstOrDefault(x=>x.Id== orderItems.Id);
            if(order == null)
            {
                return;
            }
            order.OrderId = orderItems.OrderId;
            order.ProductId = orderItems.ProductId;
            order.Quantity = orderItems.Quantity;
        }
        public static void Delete(int id)
        {
            var orderItems = OrderItems.FirstOrDefault(x => x.Id == id);
            if (orderItems is not null)
            {
                OrderItems.Remove(orderItems);
            }
        }
    }
}
