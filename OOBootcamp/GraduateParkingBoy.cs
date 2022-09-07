namespace OOBootcamp;

public class GraduateParkingBoy
{
    private List<string> parkingHistory = new List<string>();
    public string Parking(Vehicle comingVehicle, List<ParkingLot> parkingLots)
    {
        if (parkingHistory.Count == 0)
        {
            parkingHistory.Add(parkingLots[0].Name);
            return parkingLots[0].Name;
        }

        string lastParkingLotName = parkingHistory[^1];
        int result = -1;
        for (int index = 0; index < parkingLots.Count; index++)
        {
            if (parkingLots[index].Name.Equals(lastParkingLotName))
            {
                result = index;
                break;
            }
        }

        parkingHistory.Add(parkingLots[result + 1].Name);
        return parkingLots[result + 1].Name;
    }
}