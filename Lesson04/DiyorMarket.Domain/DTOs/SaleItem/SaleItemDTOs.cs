namespace DiyorMarket.Domain.DTOs.SaleItem
{
    public record SaleItemDTOs(
        int Id,
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SaleId
        );
}
