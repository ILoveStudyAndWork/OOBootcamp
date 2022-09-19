using System.Collections.Generic;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class SmartParkingBoyTest
{
    [Test]
    public void should_return_a_when_parking_given_a_have_more_available_parking_spaces()
    {
        List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new(2, 5, "b parking lot"),
            new(3, 5, "a parking lot")
        };

        SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);

        ParkingLot expectedParkingLot = smartParkingBoy.ParkVehicle(new Vehicle("coming"));

        Assert.AreEqual("a parking lot", expectedParkingLot.Name);
    }

    [Test]
    public void
        should_return_a_when_parking_given_a_and_b_have_the_same_available_count_but_a_has_higher_available_parking_rate()
    {
        List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new(2, 5, "b parking lot"),
            new(1, 5, "a parking lot")
        };

        SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);
        smartParkingBoy.ParkVehicle(new Vehicle("last parking"));

        ParkingLot expectedParkingLot = smartParkingBoy.ParkVehicle(new Vehicle("coming"));

        Assert.AreEqual("a parking lot", expectedParkingLot.Name);
    }

    [Test]
    public void should_return_throw_no_available_parking_exception_when_parking_given_both_a_and_b_are_not_available()
    {
        List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new(0, 5, "b parking lot"),
            new(0, 5, "a parking lot")
        };

        SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);

        Assert.Throws<NoParkingSlotAvailableException>(() => smartParkingBoy.ParkVehicle(new Vehicle("coming")));
    }
}