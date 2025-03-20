using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Filters;
using Skeleton.Application.Common;

namespace Skeleton.Application.Filters;

public class MapCurrentUserAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.User.Identity?.IsAuthenticated == true)
        {
            var userId = context.HttpContext.User.Claims.Single(s=> s.Type == JwtRegisteredClaimNames.Sub).Value; 

            foreach (var arg in context.ActionArguments.Values)
            {
                if (arg is BaseRequest request)
                {
                    request.CurrentUserId = userId;
                }
            }
        }

        base.OnActionExecuting(context);
    }
}
