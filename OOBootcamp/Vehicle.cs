namespace OOBootcamp;

public record Vehicle(string LicensePlate, string Type)
{
    public readonly string LicensePlate = LicensePlate;
    public readonly string Type = Type;
}