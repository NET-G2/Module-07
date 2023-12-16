using DiyorMarket.Domain.DTOs.Supplier;

namespace DiyorMarket.Domain.Interfaces.Services
{
    public interface ISupplierService
    {
        IEnumerable<SupplierDto> GetSuppliers();
        SupplierDto? GetSupplierById(int id);
        SupplierDto CreateSupplier(SupplierForCreateDto supplierToCreate);
        void UpdateSupplier(SupplierForUpdateDto supplierToUpdate);
        void DeleteSupplier(int id);
    }
}
