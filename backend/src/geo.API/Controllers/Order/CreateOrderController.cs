using geo.Application.Order.Create;
using Microsoft.AspNetCore.Mvc;

namespace geo.API.Controllers.Order;

public class CreateOrderController : ApplicationController
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromServices] CreateOrderHandler handler,
        [FromBody] CreateOrderRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);
        
        return Ok(result.Value);
    }
}