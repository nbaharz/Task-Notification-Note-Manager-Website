using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;

namespace GradProj.Infrastructure.External_Services.Amazon
{
    using System.Net.Http;

    public class AmazonProductService : IAmazonProductService//bunun icin interface yazmali miyiz
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

        public async Task<ProductDetailDto> GetProductDetailsAsync(string amazonUrl) //method imzasini (string amazonUrl, string productTitle) seklinde degistirmek gerekiyor title set edebilmek icin
        {
            var encodedUrl = Uri.EscapeDataString(amazonUrl);
            var requestUrl = $"{BaseUrl}/amz/amazon-lookup-product?url={encodedUrl}";

            var response = await _client.GetAsync(requestUrl);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Axesso API hatası: {(int)response.StatusCode} - {response.StatusCode}\nGelen içerik:\n{content}");
            }

            var parsed = JObject.Parse(content);

            return new ProductDetailDto
            {
                url = amazonUrl,
                ProductTitle = parsed["productTitle"]?.ToString(),
                Price = parsed["price"]?.Value<decimal?>(),
                RetailPrice = parsed["retailPrice"]?.Value<decimal?>(),
                PriceSaving = parsed["priceSaving"]?.ToString(),
                ProductRating = parsed["productRating"]?.ToString(),
                Seller = parsed["soldBy"]?.ToString()
            };
        }

        public async Task<DiscountInfoDto> GetDiscountInfoAsync(string amazonUrl)
        {
            var productDto = await GetProductDetailsAsync(amazonUrl);
            var priceSaving = productDto.PriceSaving;

            var result = new DiscountInfoDto
            {
                IsDiscounted = !string.IsNullOrEmpty(priceSaving),
                PriceSavingValue = priceSaving
            };

            return result;
        }
    }


}
