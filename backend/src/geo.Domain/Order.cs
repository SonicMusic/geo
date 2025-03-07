using CSharpFunctionalExtensions;

namespace geo.Domain;

public class Order
{
    // ef core
    private Order()
    {
        
    }

    public Order(Guid id, string title, string description, string client, Specialist specialist, Status status)
    {
        Id = id;
        Title = title;
        Description = description;
        Client = client;
        Specialist = specialist;
        Status = status;
    }
    
    public Guid Id { get; private set; }
    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Client { get; private set; } = default!;
    public Specialist Specialist { get; private set; } = default!;
    public Status Status { get; private set; } = default!;
    public DateTimeOffset Confirmed { get; private set; } = DateTimeOffset.MinValue;
    public DateTimeOffset Completed { get; private set; } = DateTimeOffset.MaxValue;

    public static Result<Order, string> Create(
        Guid id,
        string title, 
        string description, 
        string client, 
        Specialist specialist)
    {
        //todo validation
        var open = Domain.Status.Create("open");
        return new Order(id, title, description, client, specialist, open.Value);
    }
}