namespace DiyorMarket.Domain.DTOs.SupplyItem
{
    public record SupplyItemDTOs(
        int Id,
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SupplyId
        );
}
