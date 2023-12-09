namespace DiyorMarket.Domain.DTOs.Product
{
    public record ProductDto(
        int Id,
        string Name,
        DateTime ExpireDate,
        decimal Price,
        string Description,
        int CategoryId
        );
}
