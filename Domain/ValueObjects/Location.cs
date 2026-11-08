namespace Domain.ValueObjects;

public record Location
{
    public string City { get; } = null!;
    public string Street { get; } = null!;

    private Location(string city, string street)
    {
        City = city ?? throw new ArgumentNullException(nameof(city));
        Street = street ?? throw new ArgumentNullException(nameof(street));
    }

    public static Location Of(string city, string street)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(street);
        
        return new Location(city, street);
    }
}