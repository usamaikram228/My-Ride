namespace ClassLibrary3
{
    public class Location
    {
        //data Memebers
        private float latitude;
        private float longitude;
        
        //Constructor
        public Location()
        {
            latitude = 0;
            longitude = 0;
        }
        
        //Properties
        //latitude Property
        public float Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        //longitutude Property
        public float Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        //Functions
        public void setLocation(float start,float end)
        {
            latitude = start;
            longitude = end;
        }
    }
}