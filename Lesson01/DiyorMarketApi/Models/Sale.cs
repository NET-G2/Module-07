namespace DiyorMarketApi.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }

        public int CustomerId { get; set; }
    }
}
