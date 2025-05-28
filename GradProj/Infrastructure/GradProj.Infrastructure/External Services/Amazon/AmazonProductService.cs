using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GradProj.Infrastructure.External_Services.Amazon
{
    using System.Net.Http;

    public class AmazonProductService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://axesso-axesso-amazon-data-service-v1.p.rapidapi.com";
        private const string RapidApiKey = "5b23eae632mshd58e8e4eb65987cp1815a6jsn495e6315f66f";
        private const string RapidApiHost = "axesso-axesso-amazon-data-service-v1.p.rapidapi.com";

        public AmazonProductService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("x-rapidapi-key", RapidApiKey);
            _client.DefaultRequestHeaders.Add("x-rapidapi-host", RapidApiHost);
        }

        public async Task<string> GetProductDetailsFromUrlAsync(string amazonUrl) //Full urlyi yapistirabiliriz 
        {
            var encodedUrl = Uri.EscapeDataString(amazonUrl);
            var requestUrl = $"{BaseUrl}/amz/amazon-lookup-product?url={encodedUrl}";

            var response = await _client.GetAsync(requestUrl);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Axesso API hatası: {(int)response.StatusCode} - {response.StatusCode}\nGelen içerik:\n{content}");
            }
            
            return content;
        }

        public async Task<object> GetDiscountInfoAsync(string amazonUrl)
        {
            var json = await GetProductDetailsFromUrlAsync(amazonUrl);
            var parsed = JObject.Parse(json);

            var priceSaving = parsed["priceSaving"]?.ToString();

            if (!string.IsNullOrEmpty(priceSaving))
                return priceSaving; 

            return false;
        }
    }


}
