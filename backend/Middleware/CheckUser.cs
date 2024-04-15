using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Common.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace backend.Middleware
{
    public class CheckUser
    {
        IConfiguration _configuration;
        public CheckUser(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> IsValidUser(string phoneNumber)
        {
            using var context = new Context(_configuration);
            var user = await context.UserTBL.Where(x => x.phoneNumber == phoneNumber).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            return true;

        }
    }
}