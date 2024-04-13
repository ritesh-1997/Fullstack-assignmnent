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
        public async Task<List<MutualFundOrderTBL>> GetUserHoldings(string phoneNumber)
        {
            try
            {
                using var context = new Context();
                var payments = await context.PaymentTBL.Where(x => x.phoneNumber == phoneNumber).ToListAsync();
                var holdings = new List<MutualFundOrderTBL>();
                foreach (var payment in payments)
                {
                    var holding = await context.MutualFundOrderTBL.Where(x => x.paymentid == payment.paymentid).ToListAsync();
                    holdings.AddRange(holding);
                }
                return holdings;
            }
            catch (Exception ex) { }
            return null;
        }
    }
}