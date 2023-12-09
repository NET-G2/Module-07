using DiyorMarket.Domain.Entities;
using DiyorMarket.Infrastructure.Persistence;
using System.Linq;
using System.Security.AccessControl;

namespace DiyorMarketApi.Services
{
    public class ProductsService
    {
        private static readonly DiyorMarketDbContext _context;

        public static List<Product> GetProducts()
        => _context.Products.ToList();

        public static Product? GetProduct(int id)
            => _context.Products.FirstOrDefault(x => x.Id == id);

        public static void Create(Product product)
            => _context.Products.Add(product);

        public static void Update(Product product)
        {
            var productToUpdate = _context.Products.FirstOrDefault(x => x.Id == product.Id);

            if (productToUpdate is null)
            {
                return;
            }

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.CategoryId = product.CategoryId;
        }

        public static void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product is not null)
            {
                _context.Products.Remove(product);
            }
        }
    }
}
