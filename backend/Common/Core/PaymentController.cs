using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using backend.Common.Models;
using Newtonsoft.Json;

namespace backend.Common.Core
{
    public class PaymentController
    {
        private readonly HttpClient _client;

        public PaymentController(string baseUrl)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUrl) };

        }
        public async Task<PaymentResponse> CreatePayment(int amount)
        {
            try
            {
                var paymentRequest = new PaymentRequest()
                {
                    AccountNumber = "11200222",
                    IfscCode = "UBIT22222",
                    Amount = amount,
                    RedirectUrl = "http://localhost:3000"

                };
                var content = new StringContent(JsonConvert.SerializeObject(paymentRequest), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await _client.PostAsync("/payment", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PaymentResponse>(responseString);
                }
                else
                {
                    throw new HttpRequestException($"Error sending payment request: {response.StatusCode}");
                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}