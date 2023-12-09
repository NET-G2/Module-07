namespace DiyorMarket.Domain.DTOs.Product
{
    public record ProductForUpdateDTOs(
        int Id,
        string Name,
        string Description,
        decimal Price,
        DateTime ExpireDate,
        int CategoryId
        );
}
