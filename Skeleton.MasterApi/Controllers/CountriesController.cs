using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skeleton.Application.Common;
using Skeleton.Application.Filters;
using Skeleton.Application.Services;
using Skeleton.Application.Services.Country;

namespace Skeleton.MasterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCountries(
            [FromServices] IListServiceHandlerAsync<ListCountryRequest, CountryDto> service,
            CancellationToken cancellationToken,
            [FromQuery] ListCountryRequest request)
        {
            var response = await service.HandleAsync(request, cancellationToken);

            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCountry(
            [FromServices] IServiceHandlerAsync<GetCountryRequest, CountryDto> service,
            CancellationToken cancellationToken,
            int id)
        {
            var response = await service.HandleAsync(new GetCountryRequest { Id = id }, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        [MapCurrentUser]
        public async Task<IActionResult> PostCountry(
            [FromServices] IServiceHandlerAsync<CreateCountryRequest> service,
            CancellationToken cancellationToken,
            [FromBody] CreateCountryRequest request)
        {
            var response = await service.HandleAsync(request, cancellationToken);

            return Ok(response);
        }

        [HttpPut("id")]
        [MapCurrentUser]
        public async Task<IActionResult> PutCountry([FromServices] IServiceHandlerAsync<UpdateCountryRequest> service,
            CancellationToken cancellationToken,
            int id,
            [FromBody] UpdateCountryRequest request)
        {
            if (id != request.Id)
                throw new ArgumentException(ErrorMessages.RouteNotMatch, nameof(id));

            var response = await service.HandleAsync(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCountry(
            [FromServices] IServiceHandlerAsync<DeleteCountryRequest> service,
            CancellationToken cancellationToken,
            int id)
        {
            var response = await service.HandleAsync(new DeleteCountryRequest { Id = id }, cancellationToken);

            return Ok(response);
        }
    }
}