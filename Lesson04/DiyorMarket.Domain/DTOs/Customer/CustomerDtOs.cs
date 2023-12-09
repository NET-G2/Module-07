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
