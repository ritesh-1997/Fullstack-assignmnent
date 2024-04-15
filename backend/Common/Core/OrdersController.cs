using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Common.Models;
using Newtonsoft.Json;

namespace backend.Common.Core
{
    public class OrdersController
    {
        private readonly HttpClient _client;

        public OrdersController(HttpClient client)
        {
            _client = client;
        }
        public async Task<InvestmentResponse> BuyFunds(InvestmentRequest investmentRequest)
        {
            var url = "http://localhost:8081/order";
            var urlDocker = "http://host.docker.internal:8081/order";

            var data = new StringContent(
                JsonConvert.SerializeObject(investmentRequest),
                Encoding.UTF8,
                "application/json");

            try
            {
                var response = await _client.PostAsync(urlDocker, data);

                response.EnsureSuccessStatusCode(); // Throw exception for non-200 status codes

                // Handle successful response (optional: parse JSON message)
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<InvestmentResponse>(responseString);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error creating order: {ex.Message}");
            }
            return null;
        }

        public async Task<FundValue> GetFundMarketValue(string fundName)
        {
            try
            {
                var url = $"http://localhost:8081/market-value/{fundName}";
                var urlDocker = $"http://host.docker.internal:8081/market-value/{fundName}";
                Console.WriteLine(url);
                var response = await _client.GetAsync(urlDocker);

                if (response.IsSuccessStatusCode)
                {
                    var contentString = await response.Content.ReadAsStringAsync();
                    // Assuming the response body is a JSON string containing the market value
                    return JsonConvert.DeserializeObject<FundValue>(contentString);
                }
                else
                {
                    throw new Exception($"Failed to fetch market value. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching market value: {ex.Message}");
                return null; // Re-throw the exception for further handling (optional)
            }
        }
    }
}