using DiyorMarketApi.Models;
using System.Linq;

namespace DiyorMarketApi.Services
{
    public class ProductsService
    {
        private static List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Coca-Cola",
                Price = 2500,
                Category = "Drinks"
            },
            new Product
            {
                Id = 2,
                Name = "Fanta",
                Price = 2500,
                Category = "Drinks"
            },
            new Product
            {
                Id = 3,
                Name = "Sprite",
                Price = 2450,
                Category = "Drinks"
            },
            new Product
            {
                Id = 4,
                Name = "Snikers",
                Price = 3500,
                Category = "Chocolate"
            },
            new Product
            {
                Id = 5,
                Name = "Mars",
                Price = 3200,
                Category = "Chocolate"
            },
        };

        public static List<Product> GetProducts()
            => Products;

        public static Product? GetProduct(int id)
            => Products.FirstOrDefault(x => x.Id == id);

        public static void Create(Product product)
            => Products.Add(product);

        public static void Update(Product product)
        {
            var productToUpdate = Products.FirstOrDefault(x => x.Id == product.Id);

            if (productToUpdate is null)
            {
                return;
            }

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Category = product.Category;
        }

        public static void Delete(int id)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);

            if (product is not null)
            {
                Products.Remove(product);
            }
        }
    }
}
