using NUnit.Framework;

namespace OOBootcamp;

public class GraduateParkingBoyTest
{
    private readonly GraduateParkingBoy _graduateParkingBoy = new GraduateParkingBoy();
    
    [Test]
    public void should_park_to_first_parking_lot_when_parking_given_parking_empty_and_no_car_park()
    {
        ParkingLot[] parkingLots =
        {
            new(1, 6.0, "first parkingLot"),
            new(1, 6.0, "second parkingLot")
        };
        var comingVehicle = new Vehicle("Eligible");

        string actualParkingLotName = _graduateParkingBoy.Parking(comingVehicle, (parkingLots));
        
        Assert.AreEqual("first parkingLot", actualParkingLotName);
    } 
    
    [Test]
    public void should_park_to_second_parking_lot_when_parking_given_first_parking_lot_have_one_car_park_before()
    {
        ParkingLot[] parkingLots =
        {
            new(1, 6.0, "first parkingLot"),
            new(1, 6.0, "second parkingLot")
        };
        var firstVehicle = new Vehicle("first");
        _graduateParkingBoy.Parking(firstVehicle, (parkingLots));
        
        var secondVehicle = new Vehicle("second");
        var actualParkingName = _graduateParkingBoy.Parking(secondVehicle, (parkingLots));
        
        Assert.AreEqual("second parkingLot", actualParkingName);
        
    }

}