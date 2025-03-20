using Microsoft.AspNetCore.Mvc;
using Skeleton.Application.Services;
using Skeleton.Application.Services.Token;

namespace Skeleton.MasterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetToken([FromServices] IServiceHandler<GetTokenRequest, TokenDto> service, [FromBody] GetTokenRequest request)
        {
            var response = service.Handle(request);
            
            return Ok(response);
        }
    }
}
