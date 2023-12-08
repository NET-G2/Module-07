using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.DTOs.Customer
{
    internal record CustomerForUpdateDTOs(
        int Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber
        );
}
