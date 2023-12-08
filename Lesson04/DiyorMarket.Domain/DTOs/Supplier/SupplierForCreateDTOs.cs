using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.DTOs.Supplier
{
    public record SupplierForCreateDTOs(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Company
        );
}
