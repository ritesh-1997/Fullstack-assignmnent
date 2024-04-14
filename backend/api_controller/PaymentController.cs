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
    [HttpPost("{phoneNumber}")]
    public async Task<IActionResult> CreateOrder([FromBody] Strategy strategy, string phoneNumber)
    {
        if (strategy == null)
        {
            return BadRequest();
        }

        var res = await new backend.Common.Core.PaymentController(_client, _configuration).CreatePayment(strategy);
        return Ok(res);
    }
}