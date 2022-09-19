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
    
}