using DiyorMarket.Api.Interfaces;

namespace DiyorMarket.Api
{
    public class ProductsRepository : IProductRepository
    {
        public ProductsRepository(DatabaseContext context) 
        { }
    }
}
