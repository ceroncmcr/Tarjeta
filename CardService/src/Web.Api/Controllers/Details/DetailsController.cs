using Application.Details.Get;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Text.Json;
using Web.Api.Extensions;

namespace Web.Api.Controllers.Details;

public class DetailsController : BaseApiController
{
    private readonly ILogger<DetailsController> _logger;

    public DetailsController(ILogger<DetailsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{cardnumber}")]
    [Produces("application/json")]
    //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
    //[ProducesResponseType(typeof(ObjectResponse<InformacionTarjeta>), StatusCodes.Status200OK)]
    public async Task<IResult> GetInfoTarjeta([FromRoute] string cardnumber)
    {
        var query = new GetDetailsQuery { CardNumber = cardnumber };
        
        _logger.LogInformation(JsonSerializer.Serialize(query));

        Result<DetailsResponse> result = await Mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);        
        
    }
}
