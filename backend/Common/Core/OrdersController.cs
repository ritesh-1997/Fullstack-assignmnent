using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Common.Data;
using backend.Common.Models;
using backend.core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace backend.Common.Core
{
    public class OrdersController
    {
        private readonly HttpClient _client;
        private IConfiguration _configuration;

        public OrdersController(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }
        public async Task<Investment> BuyStrategy(string phonenNumber)
        {
            var response = new Investment();
            try
            {
                // get failed payments
                using var context = new Context(_configuration);
                var payments = await context.PaymentTBL.Where(x => !x.status && !x.isTried && x.phoneNumber == phonenNumber).ToListAsync();
                foreach (var payment in payments)
                {
                    var paymentResponse = await new PaymentController(_client, _configuration).GetPaymentDetails(payment.paymentid);
                    if (paymentResponse != null && paymentResponse.Status.ToLower() == "success")
                    {
                        // update payment status
                        payment.status = true;
                        payment.utr = paymentResponse.Utr.ToString();
                        // buy the fund
                        var strategy = await new UserInvestmentController().GetStrategy(payment.strategyName);
                        var amount = payment.amount;

                        //buy the funds and its unit
                        foreach (var fund in strategy.Funds)
                        {
                            var investmentRequest = new InvestmentRequest();
                            investmentRequest.Fund = fund.Name;
                            investmentRequest.Amount = (fund.Percentage * amount) / 100;
                            investmentRequest.PaymentId = payment.paymentid;
                            var fundResponse = await new Core.OrdersController(_client, _configuration).BuyFunds(investmentRequest);
                            if (fundResponse != null)
                            {
                                // save the funds and its unit
                                var investment = new MutualFundOrderTBL()
                                {
                                    paymentid = payment.paymentid,
                                    orderGuid = fundResponse.Data.Id,
                                    fundName = fundResponse.Data.Fund,
                                    amount = fundResponse.Data.Amount,
                                    units = fundResponse.Data.Units,
                                    status = fundResponse.Data.SucceededAt != null ? true : false,
                                    pricePerUnit = fundResponse.Data.PricePerUnit,
                                    phoneNumber = phonenNumber,
                                };

                                var order = new StrategyInvestment()
                                {
                                    strategyName = payment.strategyName,
                                    fundName = fundResponse.Data.Fund,
                                    success = investment.status
                                };

                                response.data.Add(order);
                                context.MutualFundOrderTBL.Add(investment);
                            }
                        }
                    }
                    payment.isTried = true;

                }
                context.UpdateRange(payments);
                await context.SaveChangesAsync();
                response.count = response.data.Count;
                response.success = true;
                return response;

            }
            catch (System.Exception ex)
            {
                response.success = false;
                return response;
            }


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
                var response = await _client.PostAsync(url, data);

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
                var response = await _client.GetAsync(url);

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

        public async Task<InvestmentDetails> GetFundDetails(string orderGuid)
        {
            try
            {
                var url = $"http://localhost:8081/order/{orderGuid}";
                var urlDocker = $"http://host.docker.internal:8081//order/{orderGuid}";
                Console.WriteLine(url);
                var response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var contentString = await response.Content.ReadAsStringAsync();
                    // Assuming the response body is a JSON string containing the market value
                    return JsonConvert.DeserializeObject<InvestmentDetails>(contentString);
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

        public async Task<Investment> CheckAndUpdateFailedStrategyOrder(string phoneNumber)
        {
            var response = new Investment();
            try
            {
                using var context = new Context(_configuration);
                var funds = await context.MutualFundOrderTBL.Where(x => x.status == false && x.phoneNumber == phoneNumber).ToListAsync();
                foreach (var fund in funds)
                {
                    var res = await GetFundDetails(fund.orderGuid);
                    if (res == null)
                        continue;
                    if (res.Status.ToLower() == "succeeded")
                    {
                        fund.status = true;
                        fund.updatedDate = DateTime.UtcNow;
                        fund.failedAt = res.FailedAt;
                        fund.succeededAt = res.SucceededAt;
                    }
                    else
                    {
                        fund.status = false;
                        fund.updatedDate = DateTime.UtcNow;
                        fund.failedAt = res.FailedAt;
                        fund.succeededAt = res.SucceededAt;
                    }
                    var strategy = new StrategyInvestment()
                    {
                        strategyName = "",
                        fundName = fund.fundName,
                        success = fund.status,

                    };
                    response.data.Add(strategy);
                }
                context.UpdateRange(funds);
                await context.SaveChangesAsync();
                response.success = true;
            }
            catch (System.Exception ex)
            {

                response.success = false;
            }
            return response;
        }
    }
}