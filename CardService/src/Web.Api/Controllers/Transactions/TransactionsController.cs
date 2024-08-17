using Application.Details.Get;
using Application.Transactions.Histories;
using Application.Transactions.Purchase;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Text.Json;
using Web.Api.Controllers.Details;
using Web.Api.Controllers.Transactions.Request;
using Web.Api.Extensions;

namespace Web.Api.Controllers.Transactions;

public class TransactionsController : BaseApiController
{
    private readonly ILogger<DetailsController> _logger;

    public TransactionsController(ILogger<DetailsController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("purchase")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<DetailsResponse>))]
    public async Task<IResult> GetPurchase([FromQuery] PurchaseRequest request)
    {
        var query = new GetPurchaseQuery { CardNumber = request.CardNumber, Month = request.Month };

        _logger.LogInformation(JsonSerializer.Serialize(query));

        Result<IEnumerable<PurchaseResponse>> result = await Mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);

    }

    //TODO: endpoint get history
    [HttpGet("history/{cardnumber}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<DetailsResponse>))]
    public async Task<IResult> GetHistory([FromRoute] string CardNumber, [FromQuery] int Month)
    {
        var query = new GetHistoryQuery { CardNumber = CardNumber, Month = Month };

        _logger.LogInformation(JsonSerializer.Serialize(query));

        Result<IEnumerable<HistoryResponse>> result = await Mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);

    }


    //TODO: endpoint post purchase    
    //TODO: endpoint post payment

    //TODO: enpoint post purchasetoexcel
    //TODO: endpoint get accountstatement
}
