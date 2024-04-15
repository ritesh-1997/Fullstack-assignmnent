using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Common.Models;
using backend.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace backend.api_controller
{
    [ApiController]
    [AuthenticateUser]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public OrderController(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;

        }
        [HttpPost]
        public async Task<IActionResult> GetHolding([FromBody] HoldingsRequest holdingsRequest)
        {
            if (holdingsRequest == null)
                return BadRequest("The request is null");
            if (string.IsNullOrWhiteSpace(holdingsRequest.phoneNumber))
                return BadRequest("Phone Number is required");
            if (string.IsNullOrWhiteSpace(holdingsRequest.strategyName))
                return BadRequest("Strategy Name is required");

            var res = await new backend.Common.Core.HoldingsController(_client, _configuration).GetUserHolding(holdingsRequest.phoneNumber, holdingsRequest.strategyName);
            return Ok(res);
        }

        [HttpPost("{phoneNumber}")]
        public async Task<IActionResult> GetHoldings(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return BadRequest("The request is null");


            var res = await new backend.Common.Core.HoldingsController(_client, _configuration).GetUserHoldings(phoneNumber);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(res));
            return Ok(res);
        }
    }


}