namespace OOBootcamp;

public record Vehicle(string LicensePlate)
{
    public string Type { get; init; } = "default";
}