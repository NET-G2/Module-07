using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Supply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.Interfaces.Services
{
    public interface ISupplyService
    {
        IEnumerable<SupplyDto> GetSupplies();
        SupplyDto? GetSupplyById(int id);
        SupplyDto CreateSupply(SupplyForCreateDto supplyToCreate);
        void UpdateSupply(SupplyForUpdateDto supplyToUpdate);
        void DeleteSupply(int id);
    }
}
