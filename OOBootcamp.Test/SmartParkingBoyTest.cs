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
    
    [Test]
    public void should_return_fee_when_retrieve_vehicle_given_vehicle_has_been_parked_to_parking_lot()
    {
        List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new(1, 5, "b parking lot")
        };
        SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);
        var comingVehicle = new Vehicle("coming");
        smartParkingBoy.ParkVehicle(comingVehicle);

        var fee = smartParkingBoy.RetrieveVehicle("coming");
        
        Assert.AreEqual(5, fee);
    }
    
    [Test]
    public void should_throw_exception_when_retrieve_vehicle_given_vehicle_has_not_been_parked_to_parking_lot()
    {
        List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new(1, 5, "b parking lot")
        };
        SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);
        
        Assert.Throws<VehicleNotFoundException>(() => smartParkingBoy.RetrieveVehicle("coming"));
    }
    
    [Test]
    public void should_throw_exception_when_retrieve_vehicle_given_vehicle_has_been_retrieve_from_parking_lot()
    {
        List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new(1, 5, "b parking lot")
        };
        SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);
        smartParkingBoy.ParkVehicle(new Vehicle("coming"));
        smartParkingBoy.RetrieveVehicle("coming");
            
        Assert.Throws<VehicleNotFoundException>(() => smartParkingBoy.RetrieveVehicle("coming"));
    }
}