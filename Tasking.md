## Park Vehicle

1. when 1 vehicle coming, given a and b all available and no past parking, then parking to a
2. when 1 vehicle coming, given only a not available and no past parking, then parking to b
3. when 1 vehicle coming, given a and b all available and have past parking to a, then parking to b. 
4. when 1 vehicle coming, give a and b all available and have past parking to b, then parking to a 
5. when 1 vehicle coming, give a is full and b available and past parking to a, then parking to b 
6. when 1 vehicle coming, give a is full and b available and past parking to b, then parking to b 
7. when 1 vehicle coming, give a available and b is full and past parking to a, then parking to a 
8. when 1 vehicle coming, give a available and b is full and past parking to b, then parking to b 
9. when 1 vehicle coming, given a and b all full, and throw exception

Optional: multiple parkingLots(more than 2)

## Retrieve Vehicle

<span style="color:red">
requirement to be confirmed: need to return the money to consumer?
</span>

- when 1 vehicle need to be retrieved, given vehicle have been parked inside the parking lots, 
then retrieve the vehicle and release the parking space
- when 1 vehicle need to be retrieved, given vehicle haven't been parked inside the parking lots, 
then throw VehicleNotFoundException



