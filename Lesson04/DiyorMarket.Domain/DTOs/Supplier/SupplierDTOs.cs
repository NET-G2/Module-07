using DiyorMarket.Domain.DTOs.Supply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
