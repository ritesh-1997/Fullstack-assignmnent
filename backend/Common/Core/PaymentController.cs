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

        public PaymentController(HttpClient client)
        {
            _client = client;

        }
        public async Task<PaymentResponse> CreatePayment(Strategy strategy)
        {
            try
            {
                using var context = new Context();
                var url = "http://localhost:8080/payment";
                var paymentRequest = new PaymentRequest()
                {
                    AccountNumber = "11200222",
                    IfscCode = "UBIT22222",
                    Amount = strategy.Amount,
                    RedirectUrl = "http://localhost:3000"

                };
                var content = new StringContent(JsonConvert.SerializeObject(paymentRequest), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await _client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(responseString);
                    var paymentId = paymentResponse.PaymentLink.Split('/').LastOrDefault();
                    var payment = new PaymentTBL()
                    {
                        paymentid = paymentId,
                        phoneNumber = "1111",
                        amount = strategy.Amount,
                        status = true,

                    };
                    context.PaymentTBL.Add(payment);

                    // buy the funds and its unit
                    foreach (var fund in strategy.Funds)
                    {
                        var investmentRequest = new InvestmentRequest();
                        investmentRequest.Fund = fund.Name;
                        investmentRequest.Amount = fund.Value;
                        investmentRequest.PaymentId = paymentId;
                        var fundResponse = await new Core.OrdersController(_client).BuyFunds(investmentRequest);
                        if (fundResponse != null)
                        {
                            // save the funds and its unit
                            var investment = new MutualFundOrderTBL()
                            {
                                paymentid = paymentId,
                                orderGuid = fundResponse.Data.Id,
                                fundName = fundResponse.Data.Fund,
                                amount = fundResponse.Data.Amount,
                                units = fundResponse.Data.Units,
                                status = fundResponse.Data.Status == "Submitted" ? true : false,
                                pricePerUnit = fundResponse.Data.PricePerUnit,
                            };
                            context.MutualFundOrderTBL.Add(investment);
                        }
                    }
                    await context.SaveChangesAsync();
                    return paymentResponse;
                }
                else
                {
                    throw new HttpRequestException($"Error sending payment request: {response.StatusCode}");
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
            return null;

        }
    }
}