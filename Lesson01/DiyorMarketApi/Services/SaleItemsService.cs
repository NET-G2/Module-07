using DiyorMarketApi.Models;
using System.Security.Cryptography;

namespace DiyorMarketApi.Services
{
    public class SaleItemsService
    {
        private static List<SaleItem> SaleItems = new List<SaleItem>
        {

            new SaleItem
            {
                Id = 1,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                SaleId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new SaleItem
            {
                Id = 2,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                SaleId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new SaleItem
            {
                Id = 3,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                SaleId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new SaleItem
            {
                Id = 4,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                SaleId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new SaleItem
            {
                Id = 5,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                SaleId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new SaleItem
            {
                Id = 6,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                SaleId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new SaleItem
            {
                Id = 7,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                SaleId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
            new SaleItem
            {
                Id = 8,
                UnitPrice = RandomNumberGenerator.GetInt32(20_000,350_000),
                Quantity = RandomNumberGenerator.GetInt32(15),
                SaleId = RandomNumberGenerator.GetInt32(1,8),
                ProductId = RandomNumberGenerator.GetInt32(1,8)
            },
        };

        public static List<SaleItem> GetSaleItems()
            => SaleItems;

        public static SaleItem? GetSaleitem(int id)
            => SaleItems.FirstOrDefault(x => x.Id == id);

        public static void Create(SaleItem saleItem)
            => SaleItems.Add(saleItem);

        public static void Update(SaleItem saleItem)
        {
            var saleItemToUpdate = SaleItems.FirstOrDefault(x => x.Id == saleItem.Id);

            if (saleItemToUpdate is null)
            {
                return;
            }

            saleItemToUpdate.Quantity = saleItem.Quantity;
            saleItemToUpdate.UnitPrice = saleItem.UnitPrice;
            saleItemToUpdate.SaleId = saleItem.SaleId;
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
