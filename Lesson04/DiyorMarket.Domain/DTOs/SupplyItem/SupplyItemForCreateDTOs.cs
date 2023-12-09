namespace DiyorMarket.Domain.DTOs.SupplyItem
{
    public record SupplyItemForCreateDTOs(
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SupplyId
        );
}
