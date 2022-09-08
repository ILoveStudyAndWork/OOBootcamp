using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace OOBootcamp;

public class GraduateParkingBoyTest
{
    private GraduateParkingBoy _graduateParkingBoy;

    private List<ParkingLot> parkingLots;
    private Mock<ParkingLot> parkingLotA;
    private Mock<ParkingLot> parkingLotB;

    [SetUp]
    public void SetUp()
    {
        parkingLotA = new Mock<ParkingLot>(1, 6, "first parkingLot");
        parkingLotB = new Mock<ParkingLot>(1, 6, "second parkingLot");
        parkingLots = new()
        {
            parkingLotA.Object,
            parkingLotB.Object
        };
        _graduateParkingBoy = new GraduateParkingBoy(parkingLots);
    }

    [Test]
    public void should_park_to_first_parking_lot_when_parking_given_parking_empty_and_no_car_park()
    {
        var comingVehicle = new Vehicle("Eligible");

        var actualParkingLot = _graduateParkingBoy.Parking(comingVehicle);

        Assert.AreEqual("first parkingLot", actualParkingLot.Name);
        parkingLotA.Verify(parkingLot => parkingLot.ParkVehicle(It.IsAny<Vehicle>()), Times.Once);
    }

    [Test]
    public void should_park_to_second_parking_lot_when_parking_given_first_parking_lot_have_one_car_park_before()
    {
        var firstVehicle = new Vehicle("first");
        _graduateParkingBoy.Parking(firstVehicle);

        var secondVehicle = new Vehicle("second");
        var actualParkingLot = _graduateParkingBoy.Parking(secondVehicle);

        Assert.AreEqual("second parkingLot", actualParkingLot.Name);
        parkingLotA.Verify(parkingLot => parkingLot.ParkVehicle(firstVehicle), Times.Once);
        parkingLotB.Verify(parkingLot => parkingLot.ParkVehicle(secondVehicle), Times.Once);
    }
}