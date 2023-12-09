namespace DiyorMarket.Domain.DTOs.Supplier
{
    public record SupplierForUpdateDTOs(
        int Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Company
        );
}
