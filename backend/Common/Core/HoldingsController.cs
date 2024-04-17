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
        private readonly IConfiguration _configuration;

        public HoldingsController(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }
        public async Task<HoldingsResponse> GetUserHolding(string phoneNumber, string strategyName)
        {
            try
            {
                using var context = new Context(_configuration);
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
                    var funds = await context.MutualFundOrderTBL.Where(x => x.paymentid == payment.paymentid && x.status == true)
                                                                    .ToListAsync();

                    foreach (var fund in funds)
                    {
                        var marketValue = await new Core.OrdersController(_client,_configuration).GetFundMarketValue(fund.fundName);

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
                holdingsResponse.investmentAmount = holdingsResponse.holdingDetails.Sum(x => x.investmentAmount);
                holdingsResponse.investmentMarketValue = holdingsResponse.holdingDetails.Sum(x => x.marketValue);
                return holdingsResponse;
            }
            catch (Exception ex) { }
            return null;
        }

        public async Task<UserHolidings> GetUserHoldings(string phoneNumber)
        {
            try
            {
                using var context = new Context(_configuration);
                var payments = await context.PaymentTBL.Where(x => x.phoneNumber == phoneNumber)
                                                                .ToListAsync();

                var strategies = payments.Select(x => x.strategyName).Distinct().ToList();
                var userHolidings = new UserHolidings();
                userHolidings.phoneNumber = phoneNumber;
                foreach (var strategy in strategies)
                {
                    var holding = await GetUserHolding(phoneNumber, strategy);
                    if (holding != null)
                        userHolidings.data.Add(holding);
                }

                return userHolidings;
            }
            catch (Exception ex) { }
            return null;
        }

    }
}