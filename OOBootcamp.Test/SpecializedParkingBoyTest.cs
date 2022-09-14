using System.Collections.Generic;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class SpecializedParkingBoyTest
{
    [Test]
    public void should_throw_exception_when_parking_given_special_parking_boy_has_no_certification()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(2, 5.0, "A"),
            new(3, 5.0, "B")
        };

        var specializedParkingBoy = new SpecializedParkingBoy("default", parkingLots);
        var vehicle = new Vehicle("license") { Type = "trunk" };
        Assert.Throws<CertificateNotMatchException>(() => specializedParkingBoy.ParkVehicle(vehicle));
    }

    [Test]
    public void
        should_park_to_A_when_special_vehicle_coming_given_special_parking_boy_has_certification_A_has_more_available_parking_space()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(5, 5.0, "A"),
            new(3, 5.0, "B")
        };

        var specializedParkingBoy = new SpecializedParkingBoy("trunk", parkingLots);
        var vehicle = new Vehicle("license") { Type = "trunk" };

        var parkingLot = specializedParkingBoy.ParkVehicle(vehicle);
        Assert.AreEqual("A", parkingLot.Name);
    }


    [Test]
    public void
        should_park_to_A_when_parking_given_parking_boy_has_certification_and_A_and_B_has_same_available_parking_space_but_A_has_more_available_rate()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(5, 5.0, "A"),
            new(6, 5.0, "B")
        };

        var specializedParkingBoy = new SpecializedParkingBoy("trunk", parkingLots);
        var vehicle = new Vehicle("license") { Type = "trunk" };
        specializedParkingBoy.ParkVehicle(new Vehicle("license1") { Type = "trunk" });

        var parkingLot = specializedParkingBoy.ParkVehicle(vehicle);

        Assert.AreEqual("A", parkingLot.Name);
    }

    [Test]
    public void
        should_park_to_A_when_parking_given_parking_boy_has_certification_and_A_available_and_B_is_not_available()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(5, 5.0, "A"),
            new(0, 5.0, "B")
        };
        var specializedParkingBoy = new SpecializedParkingBoy("trunk", parkingLots);
        var vehicle = new Vehicle("license") { Type = "trunk" };

        var parkingLot = specializedParkingBoy.ParkVehicle(vehicle);

        Assert.AreEqual("A", parkingLot.Name);
    }

    [Test]
    public void
        should_throw_exception_when_parking_given_parking_boy_has_certification_and_both_A_and_B_are_not_available()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(0, 5.0, "A"),
            new(0, 5.0, "B")
        };
        var specializedParkingBoy = new SpecializedParkingBoy("trunk", parkingLots);
        var vehicle = new Vehicle("license") { Type = "trunk" };

        Assert.Throws<NoParkingSlotAvailableException>(() => specializedParkingBoy.ParkVehicle(vehicle));
    }

    [Test]
    public void
        should_throw_exception_when_retrieve_given_parking_boy_vehicle_not_exist()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(1, 5.0, "A"),
        };
        var specializedParkingBoy = new SpecializedParkingBoy("trunk", parkingLots);

        Assert.Throws<VehicleNotFoundException>(() => specializedParkingBoy.RetrieveVehicle("liscens1"));
    }
    
    [Test]
    public void
        should_return_parking_fee_when_retrieve_given_vehicle_exist()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(1, 5, "A"),
        };
        var specializedParkingBoy = new SpecializedParkingBoy("default", parkingLots);
        var vehicle = new Vehicle("license") { Type = "default" };
        specializedParkingBoy.ParkVehicle(vehicle);

        var retrieveVehicle = specializedParkingBoy.RetrieveVehicle("license");
        Assert.That(() => retrieveVehicle, Is.EqualTo(5).After(1).Seconds);
    }
}