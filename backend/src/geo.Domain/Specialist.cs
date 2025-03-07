using CSharpFunctionalExtensions;

namespace geo.Domain;

public record Specialist
{
    public string Value { get; }

    private Specialist(string value)
    {
        Value = value;
    }

    public static readonly Specialist Brigade01 = new (nameof(Brigade01).ToLower());
    public static readonly Specialist Brigade02 = new (nameof(Brigade02).ToLower());
    public static readonly Specialist Brigade03 = new (nameof(Brigade03).ToLower());

    private static readonly Specialist[] _all = [Brigade01, Brigade02, Brigade03];

    public static Result<Specialist, string> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "Error";
        
        var specialist = input.Trim().ToLower();
        
        return new Specialist(specialist);
    }
}