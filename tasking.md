# SpecializedParkingBoy
## parking
- given certificate not match, should throw CertificateNotMatchException 
- given certificate match and A has more available parking space when parking then park to A  
- given certificate match and A and B has the same available parking space but A have higher available rate then parking then park to A
- given certificate match and A available and B not available when parking then park to A
- given certificate match and both A and B not available when parking then throw exception
## retrive
- given card exist when retrieve card then return the card fee
- given card not exist when retrieve card then throw VehicleNotFoundException

<hr></hr>
given special parkingboy no certificate when special vehical coming then throw exception
give special parkingboy have certificate a when special vehical a coming then smart parking