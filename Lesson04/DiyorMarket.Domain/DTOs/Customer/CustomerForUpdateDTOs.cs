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
