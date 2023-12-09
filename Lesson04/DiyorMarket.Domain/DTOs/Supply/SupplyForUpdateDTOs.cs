namespace DiyorMarket.Domain.DTOs.Supply
{
    public record SupplyForUpdateDTOs(
        int Id,
        DateTime SupplyDate,
        int SupplierId
        );
}
