using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.api_controller
{
    [ApiController]
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
        public async Task<IActionResult> GetHoldings([FromBody] HoldingsRequest holdingsRequest)
        {
            if (holdingsRequest == null)
                return BadRequest("The request is null");
            if (string.IsNullOrWhiteSpace(holdingsRequest.phoneNumber))
                return BadRequest("Phone Number is required");
            if (string.IsNullOrWhiteSpace(holdingsRequest.strategyName))
                return BadRequest("Strategy Name is required");

            var res = await new backend.Common.Core.HoldingsController(_client, _configuration).GetUserHoldings(holdingsRequest.phoneNumber, holdingsRequest.strategyName);
            return Ok(res);
        }
    }


}