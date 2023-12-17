using DiyorMarket.Domain.DTOs.Product;

namespace DiyorMarket.Domain.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        ProductDto? GetProductById(int id);
        ProductDto CreateProduct(ProductForCreateDTOs productToCreate);
        void UpdateProduct(ProductForUpdateDTOs productToUpdate);
        void DeleteProduct(int id);
    }
}
