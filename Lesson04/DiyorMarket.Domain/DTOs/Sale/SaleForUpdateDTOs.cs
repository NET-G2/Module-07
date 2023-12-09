namespace DiyorMarket.Domain.DTOs.Sale
{
    public record SaleForUpdateDTOs(
        int Id,
        DateTime SaleDate,
        int CustomerId
        );
}
