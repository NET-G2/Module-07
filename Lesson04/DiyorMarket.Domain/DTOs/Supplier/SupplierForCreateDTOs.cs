namespace DiyorMarket.Domain.DTOs.Supplier
{
    public record SupplierForCreateDTOs(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Company
        );
}
