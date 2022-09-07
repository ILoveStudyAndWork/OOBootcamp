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
            return _parkingLots[0];
        }

        string lastParkingLotName = parkingHistory[^1].Name;
        int result = -1;
        for (int index = 0; index < _parkingLots.Count; index++)
        {
            if (_parkingLots[index].Name.Equals(lastParkingLotName))
            {
                result = index;
                break;
            }
        }

        parkingHistory.Add(_parkingLots[result + 1]);
        return _parkingLots[result + 1];
    }
}