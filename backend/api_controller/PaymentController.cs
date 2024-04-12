using backend.Common.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api_controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class PaymentController : ControllerBase
{
    private string baseUrl = "http://localhost:8080";
    public async Task<IActionResult> CreateOrder()
    {
        var res = await new backend.Common.Core.PaymentController(baseUrl).CreatePayment(500);
        return Ok(res);
    }
}