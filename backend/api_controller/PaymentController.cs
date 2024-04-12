using backend.Common.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class PaymentController : ControllerBase
{
    private readonly HttpClient _client;
    public PaymentController(HttpClient client)
    {
        _client = client;

    }
    private string baseUrl = "http://localhost:8080";
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] Strategy strategy)
    {
        var res = await new backend.Common.Core.PaymentController(_client).CreatePayment(strategy);
        return Ok(res);
    }
}