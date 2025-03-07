using CSharpFunctionalExtensions;

namespace geo.Application.Order;

public interface IOrdersRepository
{
    Task<Guid> Add(Domain.Order order, CancellationToken cancellationToken = default);
    Task<Result<Domain.Order, string>> GetById(Guid guid);
}