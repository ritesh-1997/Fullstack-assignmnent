using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using backend.Common.Data;
using backend.Common.Models;
using Newtonsoft.Json;

namespace backend.Common.Core
{
    public class PaymentController
    {
        private readonly HttpClient _client;
        private IConfiguration _configuration;

        public PaymentController(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;

        }
        public async Task<PaymentResponse> CreatePayment(Strategy strategy, string phoneNumber)
        {
            var paymentResponse = new PaymentResponse();
            try
            {
                using var context = new Context(_configuration);
                var url = "http://localhost:8080/payment";
                var urlDocker = "http://host.docker.internal:8080/payment";
                var paymentRequest = new PaymentRequest()
                {
                    AccountNumber = "11200222",
                    IfscCode = "UBIT22222",
                    Amount = strategy.Amount,
                    RedirectUrl = "http://localhost:4200/investment"

                };
                var content = new StringContent(JsonConvert.SerializeObject(paymentRequest), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await _client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(responseString);
                    var paymentId = paymentResponse.PaymentLink.Split('/').LastOrDefault();
                    var payment = new PaymentTBL()
                    {
                        paymentid = paymentId,
                        phoneNumber = phoneNumber,
                        amount = strategy.Amount,
                        status = false,
                        strategyName = strategy.Name,
                        utr = "",
                        isTried = false,
                    };
                    context.PaymentTBL.Add(payment);

                    //buy the funds and its unit
                    // foreach (var fund in strategy.Funds)
                    // {
                    //     var investmentRequest = new InvestmentRequest();
                    //     investmentRequest.Fund = fund.Name;
                    //     investmentRequest.Amount = fund.Value;
                    //     investmentRequest.PaymentId = paymentId;
                    //     var fundResponse = await new Core.OrdersController(_client, _configuration).BuyFunds(investmentRequest);
                    //     if (fundResponse != null)
                    //     {
                    //         // save the funds and its unit
                    //         var investment = new MutualFundOrderTBL()
                    //         {
                    //             paymentid = paymentId,
                    //             orderGuid = fundResponse.Data.Id,
                    //             fundName = fundResponse.Data.Fund,
                    //             amount = fundResponse.Data.Amount,
                    //             units = fundResponse.Data.Units,
                    //             status = fundResponse.Data.SucceededAt != null ? true : false,
                    //             pricePerUnit = fundResponse.Data.PricePerUnit,
                    //         };
                    //         context.MutualFundOrderTBL.Add(investment);
                    //     }
                    // }


                    await context.SaveChangesAsync();
                    return paymentResponse;
                }
                else
                {
                    paymentResponse.ErrorMessage = $"Error sending payment request: {response.StatusCode}";
                    paymentResponse.Success = false;
                }
            }
            catch (System.Exception ex)
            {
                paymentResponse.ErrorMessage = $"Error : {ex.Message}";
                paymentResponse.Success = false;

            }
            return paymentResponse;

        }

        public async Task<PaymentIdResponse> GetPaymentDetails(string paymentId)
        {
            try
            {
                var url = $"http://localhost:8080/payment/{paymentId}";
                var urlDocker = $"http://host.docker.internal:8080/payment/{paymentId}";
                Console.WriteLine(url);
                var response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var contentString = await response.Content.ReadAsStringAsync();
                    // Assuming the response body is a JSON string containing the market value
                    return JsonConvert.DeserializeObject<PaymentIdResponse>(contentString);
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