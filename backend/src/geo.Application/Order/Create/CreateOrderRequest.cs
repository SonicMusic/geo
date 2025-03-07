namespace geo.Application.Order.Create;

public record CreateOrderRequest(string Title, string Description, string Client, string Specialist);