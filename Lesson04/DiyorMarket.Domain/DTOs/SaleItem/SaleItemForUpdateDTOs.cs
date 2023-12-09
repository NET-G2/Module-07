namespace DiyorMarket.Domain.DTOs.SaleItem
{
    public record SaleItemForUpdateDTOs(
        int Id,
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SaleId
        );
}
