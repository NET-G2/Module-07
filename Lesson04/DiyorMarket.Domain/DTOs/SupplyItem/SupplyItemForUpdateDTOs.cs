namespace DiyorMarket.Domain.DTOs.SupplyItem
{
    public record SupplyItemForUpdateDTOs(
        int Id,
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SupplyId
        );
}
