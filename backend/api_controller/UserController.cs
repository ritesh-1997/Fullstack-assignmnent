using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api_controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public string UserInfo()
    {
        return "User";
    }
    public string Profile(){
        return "User Profile";
    }
}