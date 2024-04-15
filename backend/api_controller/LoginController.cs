using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using backend.Common.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.ApiController;

[ApiController]
[Route("api/[controller]/[action]")]
public class LoginController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public LoginController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
    {
        if (string.IsNullOrEmpty(userLoginRequest.phoneNumber))
            return Ok("Not a valid phone number");

        return Ok(await new backend.Common.Core.LoginController(_configuration).Login(userLoginRequest.phoneNumber));
    }
}