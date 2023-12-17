using DiyorMarket.Domain.DTOs.SupplyItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.DTOs.Supply
{
    public record SupplyDTOs(
        int Id,
        DateTime SupplyDate,
        int SupplierId,
        ICollection<SupplyItemDTOs> Supplies
        );
}
