namespace OOBootcamp;

public class GraduateParkingBoy
{
    private List<string> parkingHistory = new List<string>();
    private readonly List<ParkingLot> _parkingLots;

    public GraduateParkingBoy(List<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
    }

    public string Parking(Vehicle comingVehicle)
    {
        if (parkingHistory.Count == 0)
        {
            parkingHistory.Add(_parkingLots[0].Name);
            return _parkingLots[0].Name;
        }

        string lastParkingLotName = parkingHistory[^1];
        int result = -1;
        for (int index = 0; index < _parkingLots.Count; index++)
        {
            if (_parkingLots[index].Name.Equals(lastParkingLotName))
            {
                result = index;
                break;
            }
        }

        parkingHistory.Add(_parkingLots[result + 1].Name);
        return _parkingLots[result + 1].Name;
    }
}