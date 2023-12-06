using DiyorMarket.Api.Interfaces;

namespace DiyorMarket.Api
{
    public class ProductsService : IProductService
    {
        public string MyProperty { get; set; }
        public ProductsService(
            ProductsRepository repository, 
            EmailService emailService, 
            SmsNotifictionService smsService) 
        { 
        }
    }
}
