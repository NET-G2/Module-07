using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.SupplyItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.Interfaces.Services
{
    public interface ISupplyItemService
    {
        IEnumerable<SupplyItemDto> GetSupplyItems();
        SupplyItemDto? GetSupplyItemById(int id);
        SupplyItemDto CreateSupplyItem(SupplyItemForCreateDto supplyItemToCreate);
        void UpdateSupplyItem(SupplyItemForUpdateDto supplyItemToUpdate);
        void DeleteSupplyItem(int id);
    }
}
