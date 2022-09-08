## Park Vehicle

- when 1 vehicle coming, given a and b all available and no past parking, then parking to a
- when 1 vehicle coming, given only a not available and no past parking, then parking to b
- when 1 vehicle coming, given a and b all available and have past parking to a, then parking to b. 
- when 1 vehicle coming, give a and b all available and have past parking to b, then parking to a 
- when 1 vehicle coming, give a is full and b available and past parking to a, then parking to b 
- when 1 vehicle coming, give a is full and b available and past parking to b, then parking to b 
- when 1 vehicle coming, give a available and b is full and past parking to a, then parking to a 
- when 1 vehicle coming, give a available and b is full and past parking to b, then parking to b 
- when 1 vehicle coming, given a and b all full, and throw exception

Optional: multiple parkingLots(more than 2)

## Retrieve Vehicle

<span style="color:red">
requirement to be confirmed: need to return the money to consumer?
</span>

- when 1 vehicle need to be retrieved, given vehicle have been parked inside the parking lots, 
then retrieve the vehicle and release the parking space
- when 1 vehicle need to be retrieved, given vehicle haven't been parked inside the parking lots, 
then throw VehicleNotFoundException



