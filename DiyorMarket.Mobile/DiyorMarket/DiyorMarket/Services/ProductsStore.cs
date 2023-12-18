using DiyorMarket.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Services
{
    public class ProductsStore : IDataStore<Product>
    {
        private readonly HttpClient _httpClient;

        public ProductsStore()
        {
            _httpClient = new HttpClient();
        }

        public Task<bool> AddItemAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(bool forceRefresh = false)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://mlznjrzr-7258.euw.devtunnels.ms/api/products");
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;

                return JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            }

            return Enumerable.Empty<Product>();
        }

        public Task<bool> UpdateItemAsync(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
