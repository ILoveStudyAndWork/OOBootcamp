namespace OOBootcamp;

public class SmartParkingBoy
{
    private readonly List<ParkingLot> _parkingLots;
    private readonly Dictionary<Vehicle, ParkingLot> parkingHistory = new();

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
        parkingHistory.TryAdd(vehicle, result);
        return result;
    }

    private Double GetAvailabilityRate(ParkingLot parkingLotHasMaxAvailabilityCount)
    {
        return Convert.ToDouble(parkingLotHasMaxAvailabilityCount.AvailableCount) /
               Convert.ToDouble(parkingLotHasMaxAvailabilityCount.MaxCapacity);
    }

    public double RetrieveVehicle(string licensePlate)
    {
        Vehicle vehicle = new Vehicle(licensePlate);
        if (parkingHistory.ContainsKey(vehicle))
        {
            var fee = parkingHistory[vehicle].RetrieveVehicle(vehicle);
            parkingHistory.Remove(vehicle);
            return fee;
        }

        throw new VehicleNotFoundException(vehicle);
    }
}