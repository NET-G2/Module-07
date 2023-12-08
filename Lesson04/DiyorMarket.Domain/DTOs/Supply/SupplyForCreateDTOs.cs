using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.DTOs.Supply
{
    public record SupplyForCreateDTOs(
        DateTime SupplyDate,
        int SupplierId
        );
}
