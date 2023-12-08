using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.DTOs.Product
{
    public record ProductDto(
        int Id,
        string Name,
        DateTime ExpireDate,
        decimal Price,
        string Description,
        int CategoryId
        );
}
