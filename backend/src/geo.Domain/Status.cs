using CSharpFunctionalExtensions;

namespace geo.Domain;

public record Status
{
    public string Value { get; }

    private Status(string value)
    {
        Value = value;
    }

    public static readonly Status Open = new(nameof(Open).ToLower());
    public static readonly Status Confirmed = new(nameof(Confirmed).ToLower());
    public static readonly Status Completed = new(nameof(Completed).ToLower());
    public static readonly Status Cancelled = new(nameof(Cancelled).ToLower());

    public static readonly Status[] _all = [Open, Confirmed, Completed, Cancelled];

    public static Result<Status, string> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "Error";
        
        var status = input.Trim().ToLower();
        if (_all.Any(s => s.Value == status) == false)
            return Open; //todo business logic
        
        return new Status(status);
    }
}