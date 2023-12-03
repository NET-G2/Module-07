using System.ComponentModel.DataAnnotations;

namespace DiyorMarketApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(5, ErrorMessage = "Product name must have max 5  characters")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
