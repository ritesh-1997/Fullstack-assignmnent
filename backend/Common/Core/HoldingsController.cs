using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Common.Data;
using backend.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Common.Core
{
    public class HoldingsController
    {
        private readonly HttpClient _client;
        public HoldingsController(HttpClient client)
        {
            _client = client;
        }
        public async Task<HoldingsResponse> GetUserHoldings(string phoneNumber, string strategyName)
        {
            try
            {
                using var context = new Context();
                var payments = await context.PaymentTBL.Where(x => x.phoneNumber == phoneNumber
                                                                && x.strategyName == strategyName)
                                                                .ToListAsync();
                var holdingsResponse = new HoldingsResponse();

                if (payments == null || payments.Count == 0)
                {
                    return holdingsResponse;
                }

                holdingsResponse.strategyName = strategyName;
                foreach (var payment in payments)
                {
                    var funds = await context.MutualFundOrderTBL.Where(x => x.paymentid == payment.paymentid)
                                                                    .ToListAsync();
                    foreach (var fund in funds)
                    {
                        var marketValue = await new Core.OrdersController(_client).GetFundMarketValue(fund.fundName);

                        if (marketValue == null)
                            continue;
                        var fundDetails = new HoldingDetails()
                        {
                            fundName = fund.fundName,
                            investmentAmount = fund.amount,
                            marketValue = marketValue.marketValue * fund.units == 0 ? fund.amount : marketValue.marketValue * fund.units,
                        };
                        holdingsResponse.holdingDetails.Add(fundDetails);
                    }

                }
                // Group holding details by fundName
                holdingsResponse.holdingDetails = holdingsResponse.holdingDetails
                                                            .GroupBy(x => x.fundName)
                                                            .Select(g => new HoldingDetails
                                                            {
                                                                fundName = g.Key,
                                                                investmentAmount = g.Sum(x => x.investmentAmount),
                                                                marketValue = g.Sum(x => x.marketValue)
                                                            })
                                                            .ToList();
                return holdingsResponse;
            }
            catch (Exception ex) { }
            return null;
        }
    }
}