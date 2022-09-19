namespace OOBootcamp;

public class SmartParkingBoy
{
    private readonly List<ParkingLot> _parkingLots;

    public SmartParkingBoy(List<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
    }

    public ParkingLot ParkVehicle(Vehicle vehicle)
    {
        var parkingLotHasMaxAvailabilityCount = _parkingLots.MaxBy(parkingLot => parkingLot.AvailableCount);
        parkingLotHasMaxAvailabilityCount.ParkVehicle(vehicle);
        return parkingLotHasMaxAvailabilityCount;
    }
}