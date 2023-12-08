﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.DTOs.Product
{
    public record ProductForUpdateDTOs(
        int Id,
        string Name,
        string Description,
        decimal Price,
        DateTime ExpireDate,
        int CategoryId
        );
}