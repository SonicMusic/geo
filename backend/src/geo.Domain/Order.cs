using CSharpFunctionalExtensions;

namespace geo.Domain;

public class Order
{
    // ef core
    private Order()
    {
        
    }

    public Order(string title, string description, string client, Specialist specialist, Status status)
    {
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
        string title, 
        string description, 
        string client, 
        Specialist specialist, 
        Status status)
    {
        return new Order(title, description, client, specialist, status);
    }
}