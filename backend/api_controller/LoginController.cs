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
    [HttpGet("{phoneNumber}")]
    public async Task<IActionResult> Login(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
            return Ok("Not a valid phone number");

        return Ok(await new backend.Common.Core.LoginController().Login(phoneNumber));
    }
}