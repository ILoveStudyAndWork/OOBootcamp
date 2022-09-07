using NUnit.Framework;

namespace OOBootcamp;

public class GraduateParkingBoyTest
{
    private GraduateParkingBoy _graduateParkingBoy;

    private readonly ParkingLot[] _parkingLots =
    {
        new(1, 6.0, "first parkingLot"),
        new(1, 6.0, "second parkingLot")
    };

    [SetUp]
    public void SetUp()
    {
        _graduateParkingBoy = new GraduateParkingBoy();
    }

    [Test]
    public void should_park_to_first_parking_lot_when_parking_given_parking_empty_and_no_car_park()
    {
        var comingVehicle = new Vehicle("Eligible");

        string actualParkingLotName = _graduateParkingBoy.Parking(comingVehicle, _parkingLots);

        Assert.AreEqual("first parkingLot", actualParkingLotName);
    }

    [Test]
    public void should_park_to_second_parking_lot_when_parking_given_first_parking_lot_have_one_car_park_before()
    {
        var firstVehicle = new Vehicle("first");
        _graduateParkingBoy.Parking(firstVehicle, _parkingLots);

        var secondVehicle = new Vehicle("second");
        var actualParkingName = _graduateParkingBoy.Parking(secondVehicle, _parkingLots);

        Assert.AreEqual("second parkingLot", actualParkingName);
    }
}