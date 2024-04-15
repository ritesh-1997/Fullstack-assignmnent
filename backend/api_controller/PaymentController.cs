using System.Net.Http.Headers;
using backend.Common.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class PaymentController : ControllerBase
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;
    public PaymentController(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _configuration = configuration;

    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] Strategy strategy, [FromHeader] string authorization)
    {
        var isuser = await new backend.Middleware.CheckUser(_configuration).IsValidUser(authorization);
        if (!isuser)
        {
            return Unauthorized();
        }
        if (strategy == null)
        {
            return BadRequest();
        }
        Console.WriteLine(authorization);

        var res = await new backend.Common.Core.PaymentController(_client, _configuration).CreatePayment(strategy, phoneNumber: authorization);
        return Ok(res);
    }
}