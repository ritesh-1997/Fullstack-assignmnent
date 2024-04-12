using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.ApiController;

[ApiController]
[Route("api/[controller]/[action]")]
public class LoginController : ControllerBase
{
    [HttpGet]
    public async Task<string> Login(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
            return "Not a valid phone number";

        return await new backend.Common.Core.LoginController().Login(phoneNumber);
    }
}