namespace geo.Domain;

public class Order
{
    // ef core
    private Order()
    {
        
    }

    public Order(string title, string description, string client, string specialist, string status)
    {
        Title = title;
        Description = description;
        Client = client;
        Specialist = specialist;
        Status = status;
    }
    
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Client { get; set; } = default!;
    public string Specialist { get; set; } = default!;
    public string Status { get; set; } = default!;
    public DateTimeOffset Confirmed { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset Completed { get; set; } = DateTimeOffset.MaxValue;

    public static Order Create(string title, string description, string client, string specialist, string status)
    {
        return new Order(title, description, client, specialist, status);
    }
}