using CSharpFunctionalExtensions;
using geo.Domain;

namespace geo.Application.Order.Create;

public class CreateOrderHandler
{
    private readonly IOrdersRepository _repository;

    public CreateOrderHandler(IOrdersRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<Guid, string>> Handle(CreateOrderRequest request, CancellationToken cancellationToken = default)
    {
        var id = Guid.NewGuid();

        var specialistResult = Specialist.Create(request.Specialist);
        if (specialistResult.IsFailure)
            return specialistResult.Error;
   
        var orderResult = Domain.Order.Create(
            id, 
            request.Title, 
            request.Description, 
            request.Client, 
            specialistResult.Value);
        if (orderResult.IsFailure)
            return orderResult.Error;

        await _repository.Add(orderResult.Value, cancellationToken);

        return orderResult.Value.Id;
    }
}