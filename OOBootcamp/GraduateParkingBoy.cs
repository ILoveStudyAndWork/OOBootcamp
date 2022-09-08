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
        if (parkingHistory.Count == 0)
        {
            parkingHistory.Add(_parkingLots[0]);
            _parkingLots[0].ParkVehicle(comingVehicle);
            return _parkingLots[0];
        }

        var nextParkingLot = FindNextParkingLot();
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