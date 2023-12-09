using DiyorMarket.Domain.DTOs.SupplyItem;

namespace DiyorMarket.Domain.DTOs.Supply
{
    public record SupplyDTOs(
        int Id,
        DateTime SupplyDate,
        int SupplierId,
        ICollection<SupplyItemDTOs> Supplies
        );
}
