using NUnit.Framework;

namespace OOBootcamp.Test;

public class ParkingLotTest
{
    private const string LICENSE_PLATE = "MAT-001";
    private const int MAX_CAPACITY = 3;
    private ParkingLot _parkingLot = null!;

    [SetUp]
    public void Setup()
    {
        _parkingLot = new ParkingLot(MAX_CAPACITY, 5, "cheap parking");
    }

    [Test]
    public void should_park_vehicle_successfully_when_ParkVehicle_given_parking_lot_has_available_space()
    {
        Assert.True(_parkingLot.ParkVehicle(new Vehicle(LICENSE_PLATE, "default")));
    }

    [Test]
    public void should_retrieve_vehicle_with_correct_fee_when_ParkVehicle_given_vehicle_is_found()
    {
        _parkingLot.ParkVehicle(new Vehicle(LICENSE_PLATE,"default"));

        var fee = _parkingLot.RetrieveVehicle(new Vehicle(LICENSE_PLATE, "default"));

        Assert.AreEqual(5.0, fee);
    }
}