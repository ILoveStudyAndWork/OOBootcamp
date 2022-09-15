namespace OOBootcamp;

public class GraduateParkingBoy
{
    private Dictionary<Vehicle, ParkingLot> parkingLocations;
    private readonly List<ParkingLot> _parkingLots;

    public GraduateParkingBoy(List<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
        parkingLocations = new Dictionary<Vehicle, ParkingLot>(50);
    }

    public ParkingLot Parking(Vehicle comingVehicle)
    {
        var nextParkingLot = FindNextParkingLot();
        nextParkingLot.ParkVehicle(comingVehicle);
        parkingLocations.Add(comingVehicle, nextParkingLot);
        return nextParkingLot;
    }

    private ParkingLot FindNextParkingLot()
    {
        return parkingLocations.Count == 0 ? GetFirstAvailableParkingLotInOrder() : FindNextParkingLotOfLastPark();
    }

    private ParkingLot? GetFirstAvailableParkingLotInOrder()
    {
        return _parkingLots.Find(parkingLot => parkingLot.AvailableCount > 0) ??
               throw new NoParkingSlotAvailableException();
    }

    private ParkingLot FindNextParkingLotOfLastPark()
    {
        var lastParkingLotIndex = _parkingLots.FindIndex(parkingLot => parkingLot.Equals(parkingLocations.Values.Last()));
        var firstAvailableParkingLotAfterLast =
            _parkingLots.FindIndex(lastParkingLotIndex + 1, parkingLot => parkingLot.AvailableCount > 0);
        return firstAvailableParkingLotAfterLast == -1
            ? GetFirstAvailableParkingLotInOrder()
            : _parkingLots[firstAvailableParkingLotAfterLast];
    }

    public double RetrieveVehicle(string licensePlate)
    {
        var vehicle = new Vehicle(licensePlate);
        return parkingLocations.ContainsKey(vehicle) ? parkingLocations[vehicle].RetrieveVehicle(vehicle) : 0.0;
    }
}