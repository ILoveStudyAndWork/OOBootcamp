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

    private void SetUpWithDefault()
    {
        parkingLotA = new Mock<ParkingLot>(1, 6, "a parking lot");
        parkingLotB = new Mock<ParkingLot>(1, 6, "b parking lot");
        parkingLots = new List<ParkingLot>
        {
            parkingLotA.Object,
            parkingLotB.Object
        };
        _graduateParkingBoy = new GraduateParkingBoy(parkingLots);
    }

    [Test]
    public void should_park_to_a_when_parking_given_a_and_b_all_available_and_no_past_parking()
    {
        SetUpWithDefault();
        var comingVehicle = new Vehicle("Coming");

        var actualParkingLot = _graduateParkingBoy.Parking(comingVehicle);

        Assert.AreEqual("a parking lot", actualParkingLot.Name);
        parkingLotA.Verify(parkingLot => parkingLot.ParkVehicle(It.IsAny<Vehicle>()), Times.Once);
    }

    [Test]
    public void should_park_to_b_when_parking_given_a_not_available_and_no_past_parking()
    {
        parkingLotA = new Mock<ParkingLot>(MockBehavior.Default,0, 6, "a parking lot");
        parkingLotB = new Mock<ParkingLot>(1, 6, "b parking lot");
        parkingLots = new List<ParkingLot>
        {
            parkingLotA.Object,
            parkingLotB.Object
        };
        _graduateParkingBoy = new GraduateParkingBoy(parkingLots);
        var comingVehicle = new Vehicle("Coming");

        var actualParkingLot = _graduateParkingBoy.Parking(comingVehicle);

        Assert.AreEqual("b parking lot", actualParkingLot.Name);
        parkingLotB.Verify(parkingLot => parkingLot.ParkVehicle(It.IsAny<Vehicle>()), Times.Once);
    }

    [Test]
    public void should_park_to_b_when_parking_given_a_and_b_available_and_have_past_parking_to_a()
    {
        SetUpWithDefault();
        var pastVehicle = new Vehicle("last park");
        _graduateParkingBoy.Parking(pastVehicle);

        var comingVehicle = new Vehicle("Coming");
        var actualParkingLot = _graduateParkingBoy.Parking(comingVehicle);

        Assert.AreEqual("b parking lot", actualParkingLot.Name);
        parkingLotA.Verify(parkingLot => parkingLot.ParkVehicle(pastVehicle), Times.Once);
        parkingLotB.Verify(parkingLot => parkingLot.ParkVehicle(comingVehicle), Times.Once);
    }
}