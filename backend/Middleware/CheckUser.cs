using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Common.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.Middleware
{
    public class AuthenticateUser : ActionFilterAttribute
    {
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {

            }
            // if(context.HttpContext.Request.Headers.ContainsKey("Authorization")){
            //     var userId = context.HttpContext.Request.Headers["Authorization"].ToString();
            //     context.Controller.
            // }
            

            base.OnActionExecuting(context);
        }
    }
}