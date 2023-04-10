namespace ClassLibraryPasssenger
{
    public class Passenger
    {
        private string name;
        private string phoneNo;

        //Constructor

        public Passenger()
        {
            name = "";
            phoneNo = string.Empty;
        }

        //Properties
        public string Name
        { 
            get { return name; }
            set { name = value; }
        }

        //PhoneNumber Property
        public string PhoneNo
        {
            get { return phoneNo; }
            set {
                foreach (char i in value)
                {

                    if (i < '0' || i > '9')
                    {
                        Console.WriteLine("Invalid Number");
                        return;
                    }
                }
                phoneNo = value; }    
        }

    }
}