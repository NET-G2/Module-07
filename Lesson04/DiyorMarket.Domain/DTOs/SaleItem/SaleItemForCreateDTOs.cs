namespace DiyorMarket.Domain.DTOs.SaleItem
{
    public record SaleItemForCreateDTOs(
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SaleId
        );
}
