using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
