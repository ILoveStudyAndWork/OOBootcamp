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
        var maxAvailabilityCount = _parkingLots.Max(parkingLot => parkingLot.AvailableCount);
        if (maxAvailabilityCount == 0)
        {
            throw new NoParkingSlotAvailableException();
        }
        var result = _parkingLots.FindAll(parkingLot => parkingLot.AvailableCount == maxAvailabilityCount)
            .MaxBy(GetAvailabilityRate);

        result.ParkVehicle(vehicle);
        return result;
    }

    private Double GetAvailabilityRate(ParkingLot parkingLotHasMaxAvailabilityCount)
    {
        return Convert.ToDouble(parkingLotHasMaxAvailabilityCount.AvailableCount) /
               Convert.ToDouble(parkingLotHasMaxAvailabilityCount.MaxCapacity);
    }
}