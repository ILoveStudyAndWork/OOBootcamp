using System.Collections.Generic;
using NUnit.Framework;

namespace OOBootcamp;

public class GraduateParkingBoyTest
{
    private GraduateParkingBoy _graduateParkingBoy;

    private List<ParkingLot> parkingLots;
    private ParkingLot parkingLotA;
    private ParkingLot parkingLotB;

    private void SetUpWithDefault()
    {
        parkingLotA = new ParkingLot(2, 6, "a parking lot");
        parkingLotB = new ParkingLot(2, 6, "b parking lot");
        parkingLots = new List<ParkingLot>
        {
            parkingLotA, parkingLotB
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
    }

    [Test]
    public void should_park_to_b_when_parking_given_a_not_available_and_no_past_parking()
    {
        parkingLotA = new ParkingLot(0, 6, "a parking lot");
        parkingLotB = new ParkingLot(1, 6, "b parking lot");
        parkingLots = new List<ParkingLot>
        {
            parkingLotA, parkingLotB
        };
        _graduateParkingBoy = new GraduateParkingBoy(parkingLots);
        var comingVehicle = new Vehicle("Coming");

        var actualParkingLot = _graduateParkingBoy.Parking(comingVehicle);

        Assert.AreEqual("b parking lot", actualParkingLot.Name);
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
    }

    [Test]
    public void should_park_to_a_when_parking_given_a_and_b_available_and_have_past_parking_to_b()
    {
        SetUpWithDefault();
        var secondLastVehicle = new Vehicle("second last park");
        _graduateParkingBoy.Parking(secondLastVehicle);
        var lastPastVehicle = new Vehicle("last park");
        _graduateParkingBoy.Parking(lastPastVehicle);

        var comingVehicle = new Vehicle("Coming");
        var actualParkingLot = _graduateParkingBoy.Parking(comingVehicle);

        Assert.AreEqual("a parking lot", actualParkingLot.Name);
    }

    [Test]
    public void should_park_to_b_when_parking_given_a_not_available_and_b_available_and_have_past_parking_to_a()
    {
        parkingLotA = new ParkingLot(1, 6, "a parking lot");
        parkingLotB = new ParkingLot(2, 6, "b parking lot");
        parkingLots = new List<ParkingLot>
        {
            parkingLotA,
            parkingLotB
        };
        _graduateParkingBoy = new GraduateParkingBoy(parkingLots);
        var lastPastVehicle = new Vehicle("last park");
        _graduateParkingBoy.Parking(lastPastVehicle);

        var comingVehicle = new Vehicle("Coming");
        var actualParkingLot = _graduateParkingBoy.Parking(comingVehicle);

        Assert.AreEqual("b parking lot", actualParkingLot.Name);
    }

    [Test]
    public void should_park_to_b_when_parking_given_a_not_available_and_b_available_and_have_past_parking_to_b()
    {
        parkingLotA = new ParkingLot(1, 6, "a parking lot");
        parkingLotB = new ParkingLot(2, 6, "b parking lot");
        parkingLots = new List<ParkingLot>
        {
            parkingLotA, parkingLotB
        };
        _graduateParkingBoy = new GraduateParkingBoy(parkingLots);
        var secondLastVehicle = new Vehicle("second last park");
        _graduateParkingBoy.Parking(secondLastVehicle);
        var lastPastVehicle = new Vehicle("last park");
        _graduateParkingBoy.Parking(lastPastVehicle);

        var comingVehicle = new Vehicle("Coming");
        var actualParkingLot = _graduateParkingBoy.Parking(comingVehicle);

        Assert.AreEqual("b parking lot", actualParkingLot.Name);
    }

    [Test]
    public void should_park_to_a_when_parking_given_b_not_available_and_a_available_and_have_past_parking_to_a()
    {
        parkingLotA = new ParkingLot(2, 6, "a parking lot");
        parkingLotB = new ParkingLot(0, 6, "b parking lot");
        parkingLots = new List<ParkingLot>
        {
            parkingLotA, parkingLotB
        };
        _graduateParkingBoy = new GraduateParkingBoy(parkingLots);
        var lastPastVehicle = new Vehicle("last park");
        _graduateParkingBoy.Parking(lastPastVehicle);

        var comingVehicle = new Vehicle("Coming");
        var actualParkingLot = _graduateParkingBoy.Parking(comingVehicle);

        Assert.AreEqual("a parking lot", actualParkingLot.Name);
    }

    [Test]
    public void should_park_to_a_when_parking_given_b_not_available_and_a_available_and_have_past_parking_to_b()
    {
        parkingLotA = new ParkingLot(2, 6, "a parking lot");
        parkingLotB = new ParkingLot(1, 6, "b parking lot");
        parkingLots = new List<ParkingLot>
        {
            parkingLotA, parkingLotB
        };
        _graduateParkingBoy = new GraduateParkingBoy(parkingLots);
        var secondLastVehicle = new Vehicle("second last park");
        _graduateParkingBoy.Parking(secondLastVehicle);
        var lastPastVehicle = new Vehicle("last park");
        _graduateParkingBoy.Parking(lastPastVehicle);

        var comingVehicle = new Vehicle("Coming");
        var actualParkingLot = _graduateParkingBoy.Parking(comingVehicle);

        Assert.AreEqual("a parking lot", actualParkingLot.Name);
    }

    [Test]
    public void should_throw_exception_when_parking_given_both_a_and_b_are_not_available_()
    {
        parkingLotA = new ParkingLot(0, 6, "a parking lot");
        parkingLotB = new ParkingLot(0, 6, "b parking lot");
        parkingLots = new List<ParkingLot>
        {
            parkingLotA, parkingLotB
        };
        _graduateParkingBoy = new GraduateParkingBoy(parkingLots);
        var comingVehicle = new Vehicle("Coming");

        Assert.Throws<NoParkingSlotAvailableException>(() => _graduateParkingBoy.Parking(comingVehicle));
    }
    
    [Test]
    public void should_return_fee_when_retrieve_vehicle_given_vehicle_exist()
    {
        parkingLotA = new ParkingLot(1, 6, "a parking lot");
        parkingLots = new List<ParkingLot>
        {
            parkingLotA
        };
        _graduateParkingBoy = new GraduateParkingBoy(parkingLots);
        var comingVehicle = new Vehicle("Coming");
        _graduateParkingBoy.Parking(comingVehicle);
        double fee = _graduateParkingBoy.RetrieveVehicle("Coming");

        Assert.That(() => fee, Is.EqualTo(6).After(1).Seconds);
    }
}