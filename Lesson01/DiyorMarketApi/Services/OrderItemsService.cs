using DiyorMarketApi.Models;
using System.Security.Cryptography;

namespace DiyorMarketApi.Services
{
    public class OrderItemsService
    {
        private static List<OrderItem> SaleItems = new List<OrderItem>
        {

            new OrderItem
            {
                Id = 1,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                OrderId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new OrderItem
            {
                Id = 2,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                OrderId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new OrderItem
            {
                Id = 3,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                OrderId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new OrderItem
            {
                Id = 4,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                OrderId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new OrderItem
            {
                Id = 5,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                OrderId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new OrderItem
            {
                Id = 6,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                OrderId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new OrderItem
            {
                Id = 7,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                OrderId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new OrderItem
            {
                Id = 8,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                OrderId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
        };

        public static List<OrderItem> GetSaleItems()
            => SaleItems;

        public static OrderItem? GetSaleitem(int id)
            => SaleItems.FirstOrDefault(x => x.Id == id);

        public static void Create(OrderItem saleItem)
            => SaleItems.Add(saleItem);

        public static void Update(OrderItem saleItem)
        {
            var saleItemToUpdate = SaleItems.FirstOrDefault(x => x.Id == saleItem.Id);

            if (saleItemToUpdate is null)
            {
                return;
            }

            saleItemToUpdate.Quantity = saleItem.Quantity;
            saleItemToUpdate.UnitPrice = saleItem.UnitPrice;
            saleItemToUpdate.OrderId = saleItem.OrderId;
            saleItemToUpdate.ProductId = saleItem.ProductId;
        }

        public static void Delete(int id)
        {
            var saleItems = SaleItems.FirstOrDefault(x => x.Id == id);

            if (saleItems is not null)
            {
                SaleItems.Remove(saleItems);
            }
        }
    }
}
