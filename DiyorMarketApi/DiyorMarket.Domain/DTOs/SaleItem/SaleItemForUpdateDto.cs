namespace DiyorMarket.Domain.DTOs.SaleItem
{
    public record SaleItemForUpdateDto(
        int Id,
        int Quantity,
        int ProductId,
        int SaleId);
}
