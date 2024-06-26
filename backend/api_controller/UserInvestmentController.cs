using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.core;
namespace TodoApi.ApiController;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserInvestmentController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetInvestmentStrategies()
    {
        var res = await new backend.core.UserInvestmentController().Stratagies();
        return Ok(res);
    }

}