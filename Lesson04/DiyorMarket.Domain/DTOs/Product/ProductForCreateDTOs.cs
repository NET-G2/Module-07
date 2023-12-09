namespace DiyorMarket.Domain.DTOs.Product
{
    public record ProductForCreateDTOs(
        string Name,
        string Description,
        decimal Price,
        DateTime ExpireDate,
        int CategoryId
        );
}
