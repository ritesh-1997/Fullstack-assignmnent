using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Common.Core;

public class LoginController
{
    public async Task<string> Login(string phoneNumber)
    {
        using var context = new Context();
        var user = await context.UserTBL.FirstOrDefaultAsync(x => x.phoneNumber == phoneNumber);
        if (user == null)
        {
            user = new Models.UserTBL()
            {
                phoneNumber = phoneNumber,
            };
            context.Add(user);
            await context.SaveChangesAsync();
        }
        return "Login Successfully";
    }
}
