using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Common.Data;
using backend.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Common.Core;

public class LoginController
{
    private IConfiguration _configuration;
    public LoginController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<UserLoginResponse> Login(string phoneNumber)
    {
        UserLoginResponse loginResponse = new UserLoginResponse();
        try
        {
            using var context = new Context(_configuration);
            var user = await context.UserTBL.FirstOrDefaultAsync(x => x.phoneNumber == phoneNumber);
            if (user == null)
            {
                user = new Models.UserTBL()
                {
                    phoneNumber = phoneNumber,
                };
                context.Add(user);
                await context.SaveChangesAsync();
                loginResponse.success = true;
                loginResponse.message = "Success, User created.";
                loginResponse.phoneNumber = phoneNumber;
            }
            loginResponse.success = true;
            loginResponse.message = "Success, login Successful.";
            loginResponse.phoneNumber = phoneNumber;
            return loginResponse;
        }
        catch (Exception ex)
        {
            loginResponse.success = false;
            loginResponse.message = "Login failed";
            return loginResponse;
        }
    }
}
