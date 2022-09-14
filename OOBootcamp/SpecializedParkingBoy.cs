namespace OOBootcamp;

public class SpecializedParkingBoy : SmartParkingBoy
{
    private readonly string _certificate;
    public SpecializedParkingBoy(string certificate, List<ParkingLot> parkingLots) : base(parkingLots)
    {
        this._certificate = certificate;
    }

    public ParkingLot ParkVehicle(Vehicle vehicle)
    {
        if (!vehicle.Type.Equals(_certificate)) throw new CertificateNotMatchException();
        return base.ParkVehicle(vehicle);
    }
    
}