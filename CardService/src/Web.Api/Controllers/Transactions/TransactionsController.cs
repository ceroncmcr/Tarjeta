using Application.Details.Get;
using Application.Transactions.Histories;
using Application.Transactions.Purchase.Create;
using Application.Transactions.Purchase.Get;
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
    
    [HttpGet("purchase/{cardnumber}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<DetailsResponse>))]
    public async Task<IResult> GetPurchase([FromRoute] string CardNumber, [FromQuery] int Month)
    {
        var query = new GetPurchaseQuery { CardNumber = CardNumber, Month = Month };

        _logger.LogInformation(JsonSerializer.Serialize(query));

        Result<IEnumerable<PurchaseResponse>> result = await Mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);

    }
    
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

    [HttpPost("purchase")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<DetailsResponse>))]
    public async Task<IResult> CreatePurchase([FromBody] PurchaseRequest request)
    {
        //TODO: Add AutoMapper
        var command = new CreatePurchaseCommand { CardNumber = request.CardNumber, PaymentDate = request.PaymentDate, Amount = request.Amount, Description = request.Description };

        _logger.LogInformation(JsonSerializer.Serialize(command));

        Result<CreatePurchaseResponse> result = await Mediator.Send(command);

        return result.Match(Results.Ok, CustomResults.Problem);

    }




    //TODO: endpoint post purchase    
    //TODO: endpoint post payment
    //TODO: endpoint get accountstatement to pdf
    //TODO: enpoint post purchasetoexcel

}
