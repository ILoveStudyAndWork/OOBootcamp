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
        var nextParkingLot = FindNextParkingLot();
        nextParkingLot.ParkVehicle(comingVehicle);
        parkingHistory.Add(nextParkingLot);
        return nextParkingLot;
    }

    private ParkingLot FindNextParkingLot()
    {
        return parkingHistory.Count == 0 ? GetFirstAvailableParkingLotInOrder() : FindNextParkingLotOfLastPark();
    }

    private ParkingLot? GetFirstAvailableParkingLotInOrder()
    {
        return _parkingLots.Find(parkingLot => parkingLot.AvailableCount > 0);
    }

    private ParkingLot FindNextParkingLotOfLastPark()
    {
        var lastParkingLotIndex = _parkingLots.FindIndex(parkingLot => parkingLot.Equals(parkingHistory[^1]));
        var firstAvailableParkingLotAfterLast = _parkingLots.FindIndex(lastParkingLotIndex + 1, parkingLot => parkingLot.AvailableCount > 0);
        return firstAvailableParkingLotAfterLast == -1 ? GetFirstAvailableParkingLotInOrder() : _parkingLots[firstAvailableParkingLotAfterLast];
    }
}