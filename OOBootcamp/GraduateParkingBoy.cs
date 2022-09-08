namespace OOBootcamp;

public class GraduateParkingBoy
{
    private List<ParkingLot> parkingHistory = new();
    private readonly List<ParkingLot> _parkingLots;

    public GraduateParkingBoy(List<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
    }

    public ParkingLot Parking(Vehicle comingVehicle)
    {
        var nextParkingLot = parkingHistory.Count == 0 ? _parkingLots[0] : FindNextParkingLot();
        nextParkingLot.ParkVehicle(comingVehicle);
        parkingHistory.Add(nextParkingLot);
        return nextParkingLot;
    }

    private ParkingLot FindNextParkingLot()
    {
        var lastParkingLotIndex = _parkingLots.FindIndex(parkingLot => parkingLot.Equals(parkingHistory[^1]));
        return _parkingLots[lastParkingLotIndex + 1];
    }
}