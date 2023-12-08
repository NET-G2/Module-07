using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.DTOs.Customer
{
    public record CustomerDtOs(
        int Id,
        string Name,
        int Age,
        string PhoneNumber,
        string Email,
        ICollection<CustomerDtOs> Customers
        );
    
}
