namespace DiyorMarket.Domain.DTOs.Product
{
    public record ProductForCreateDto(
        string Name,
        string Description,
        decimal Price,
        DateTime ExpireDate,
        int CategoryId);
}
