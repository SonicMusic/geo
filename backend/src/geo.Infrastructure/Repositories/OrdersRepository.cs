using CSharpFunctionalExtensions;
using geo.Application.Order;
using geo.Domain;
using Microsoft.EntityFrameworkCore;

namespace geo.Infrastructure.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrdersRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Add(Order order, CancellationToken cancellationToken = default)
    {
        await _dbContext.Orders.AddAsync(order, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return order.Id;
    }

    public async Task<Result<Order, string>> GetById(Guid guid)
    {
        var order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == guid);
        if (order is null)
            return "Order not found";

        return order;
    }
}