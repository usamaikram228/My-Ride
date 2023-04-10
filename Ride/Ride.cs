using ClassLibrary3;
using ClassLibraryDriver;
using ClassLibraryPasssenger;
using ClassLibraryVehicle;
namespace ClassLibraryRide
{
    public class Ride
    {
        //Data Memebers
        private Location start_location;
        private Location end_location;
        private int price;
        private Driver driver;
        private Passenger passenger;

        //Constructor
        public Ride()
        {
            start_location = new Location();
            end_location = new Location();
            driver = new Driver();
            passenger = new Passenger();
            price = 0;
        }

        //StartLocation Property 
        public Location StartLocation
        {
            get { return start_location; }
            set { start_location = value; }

        }
        //end Location Property
        public Location EndLocation
        {
            get { return end_location; }
            set { end_location = value; }
        }
        //Price Property
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
            }
        }
        //Driver Property
        public Driver Driver
        {
            get { return driver; }
            set { driver = value; }
        }
        //Passenger Property
        public Passenger Passenger 
        {
            get { return passenger; }
            set { passenger = value; }
        }

        //Methods 
        //Function Assign Passenger
        public void assignPassenger(Passenger pas )
        {
            passenger = pas;
        }
        public void assignDriver(Driver div)
        {
            driver = div;
        }
        //Bokk Ride Function
        //public void bookRide(Location start, Location end)
        //{

        //}
        //Get Location Method
        public void getLocation(Location start,Location end)
        {
            start_location = start;
            end_location = end;
        }
        //Calculate Price

        public int calculatePrice()
        {
            
            //Euclidean Distance
            float lanTemp = end_location.Latitude - start_location.Latitude;
           
            double powTemp = Math.Pow(lanTemp, 2);
            
            float lonTemp = end_location.Longitude - start_location.Longitude;
            double powTemp2= Math.Pow(lonTemp, 2);
            double distance = powTemp2 + powTemp;
            distance = Math.Sqrt(distance);
           
            //Fuel Price 272
            double fuelPrice = 272;
            double price = 0;
            double commision = 0;
            
            if(driver.Vehicle.Type == "bike")
            {
               // Console.WriteLine("ooooo");
                price = (distance * fuelPrice) / 50;
                commision = (5 / 100) * price;
                price = price + commision;
                return Convert.ToInt32(price);
            }
            else if(driver.Vehicle.Type == "rikshaw")
            {
                price = (distance * fuelPrice) / 35;
                commision = (10 / 100) * price;
                price = price + commision;
                return Convert.ToInt32(price);
            }
            else if( driver.Vehicle.Type == "car")
            {
                price = (distance * fuelPrice) / 15;
                commision = (20 / 100) * price;
                price = price + commision;
                return Convert.ToInt32(price);
            }
            else
            {
                return 0;
            }

        }

        //Give Rating
        public void giveRating(int rating)
        {
            if(rating >= 0 && rating <= 5)
            {
                driver.Rating.Add(rating);
            }
            else
            {
                return;
            }
        }
    }

    
   
}