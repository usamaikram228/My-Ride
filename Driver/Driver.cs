using System.Collections;
using ClassLibrary3;
using ClassLibraryVehicle;
namespace ClassLibraryDriver
{
    public class Driver
    {
        private string name;
        private int age;
        private string gender;
        private string address;
        private string phoneNo;
        private Location currentLocation;
        private Vehicle vehicle;
        private bool availability;
        private List<int> rating;

        //Constructor
        public Driver()
        {
            name = " ";
            age = 0;
            gender = " ";
            address = " ";
            phoneNo = " ";
            currentLocation = new Location();
            vehicle = new Vehicle();
            availability = false;
            rating = new List<int>();
        }
        public Vehicle Vehicle { get { return vehicle; }
            set { vehicle = value; }
        }
        //Property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //property Curent Location
        public Location CurrentLocation
        {
            get { return currentLocation; }
            set { currentLocation = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { 
                gender = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if(value >= 18)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Age is Not Suitable");
                    return;
                }
               
            }
        }
        //Property address
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        //property Phone Number
        public string PhoneNo
        {
            get { return phoneNo; }
                                                                        
            set {                                                         //Check for phone Number      
                foreach(char i in value)
                {
                    
                    if(i <'0' || i>'9')
                    {
                        Console.WriteLine("Invalid Number");             
                        return;
                    }
                }
                phoneNo = value; }
        }
        //property vehicle
      
        //property availability
        public bool Availability
        {
            get { return availability; }
            set
            {
                availability = value;
            }
        }
        //property Rating
        public List<int> Rating
        {
            get { return rating; }
            set {

                rating = value; }
        }


        //Methods

        public void updateAvailability()
        {
            if(availability == false)
            {
                availability = true;
            }
            else
            {
                availability = false;
            }
        }

        public int getRating()
        {                                                                //get Rating   
            int sum = 0;
            int n = 0;
            foreach(int i in rating)
            {
                sum = sum + i;
                n = n + 1;
            }
            return sum / n;
        }
        //update location
        public void updateLocation(float lang,float longt)
        {
            currentLocation.setLocation(lang, longt);
        }
    }
}