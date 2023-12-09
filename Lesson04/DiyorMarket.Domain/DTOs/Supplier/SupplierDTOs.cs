using DiyorMarket.Domain.DTOs.Supply;

namespace DiyorMarket.Domain.DTOs.Supplier
{
    public record SupplierDTOs(
        int Id,
        string Name,
        string PhoneNumber,
        string Company,
        ICollection<SupplyDTOs> Supplies
        );
}
