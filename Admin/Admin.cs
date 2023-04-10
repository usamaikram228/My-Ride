using ClassLibraryDriver;
using ClassLibraryVehicle;
using System.Collections;
using System.Globalization;

namespace ClassLibraryAdmin
{
    public class Admin
    {
        private Dictionary<int,Driver> drivers;
        
        //property
        public Dictionary<int,Driver> Drivers
        { get { return drivers; } 
          set { drivers = value; }
        }
        //constructor
        public Admin()
        {
            drivers = new Dictionary<int, Driver>();
        }
        //Functions

        //AddDriver
        public void addDriver(int id)
        {
            Driver driver = new Driver();

            Console.WriteLine("Enter Your Name: ");
            driver.Name = Console.ReadLine();

            Console.WriteLine("Enter Your age: ");
            driver.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Your Gender : ");
            driver.Gender = Console.ReadLine();

            Console.WriteLine("Enter Your address : ");
            driver.Address = Console.ReadLine();

            Console.WriteLine("Enter Vehicle Type : ");
            driver.Vehicle.Type = Console.ReadLine();

            Console.WriteLine("Enter Vehicle Model : ");
            driver.Vehicle.Model = Console.ReadLine();

            Console.WriteLine("Enter Vehicle license Plate : ");
            driver.Vehicle.LicensePlate = Console.ReadLine();
           

            //id given

            foreach (int i in drivers.Keys)
            {
                if(i  == id)
                {
                    //Console.WriteLine("Id is already given");
                    id = id + 1;
                }
            }
            drivers.Add(id,driver);
        }

        //Updation of driver
        public void updateDriver()
        {
            Console.WriteLine("Enter Driver ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            //Check for Driver Existance
            foreach(int i in drivers.Keys)
            {
                if(i == id)
                {
                    Console.WriteLine("....Driver With ID " + i + " exists....");
                    break;
                }
            }

            
           string tempName = drivers[id].Name;
            Console.WriteLine("Enter Your Name: ");
            string n = Console.ReadLine();
            if (n == "")
            {
                drivers[id].Name = tempName;
            }
            else
            {
                drivers[id].Name = n;
            }


            int tempAge = drivers[id].Age;
            Console.WriteLine("Enter Your age: ");
           string a = Console.ReadLine();

            if (a == "")
            {
                drivers[id].Age = tempAge;
            }
            else
            {
                drivers[id].Age = Convert.ToInt32(a);
            }


            string tempGender = drivers[id].Gender;
            Console.WriteLine("Enter Your Gender : ");
            string g = Console.ReadLine();

            if (g == "")
            {
                drivers[id].Gender = tempGender;
            }
            else
            {
                drivers[id].Gender = g;
            }


            string tempAddress = drivers[id].Address;
            Console.WriteLine("Enter Your address : ");
            string ad = Console.ReadLine();
            if (ad == "")
            {
                drivers[id].Address = tempAddress;
            }
            else
            {
                drivers[id].Address = ad;
            }

            string tempType = drivers[id].Vehicle.Type;
            Console.WriteLine("Enter Vehicle Type : ");
            string t = Console.ReadLine();
            if (t == "")
            {
                drivers[id].Vehicle.Type = tempType;
            }
            else
            {
                drivers[id].Vehicle.Type = t;
            }

            //Vehicle Model Updation

            string tempModel = drivers[id].Vehicle.Model;
            Console.WriteLine("Enter Vehicle Model : ");
            string m = Console.ReadLine();
            if (m == "")
            {
                drivers[id].Vehicle.Model = tempModel;
            }
            else
            {
                drivers[id].Vehicle.Model = m;
            }

            //Vehicle license Plate Updation

            string tempPlate = drivers[id].Vehicle.LicensePlate;
            Console.WriteLine("Enter Vehicle License Plate : ");
            string p = Console.ReadLine();
            if (p == "")
            {
                drivers[id].Vehicle.LicensePlate = tempPlate;
            }
            else
            {
                drivers[id].Vehicle.LicensePlate = p;
            }
        }

        //Method
        //Search Driver
        public void searchDriver()
        {
            Console.WriteLine("Enter Driver Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach(int i in drivers.Keys)
            {
                if(i == id)
                {
                    Console.WriteLine("Name : " + drivers[i].Name);
                    Console.WriteLine("Age : " + drivers[i].Age);
                    Console.WriteLine("Gender : " + drivers[i].Gender);
                    Console.WriteLine("V.Type : " + drivers[i].Vehicle.Type);
                    Console.WriteLine("V.Model : " + drivers[i].Vehicle.Model);
                    Console.WriteLine("V.License : " + drivers[i].Vehicle.LicensePlate);
                }
            }
            List<Driver> searchList = new List<Driver>();

            //BY Name Search
            Console.WriteLine("Enter Name : ");
            string n = Console.ReadLine();

            if( n!= "")
            {
                foreach(int i in drivers.Keys)
                {
                    if (drivers[i].Name == n)
                    {
                        searchList.Add(drivers[i]);
                    }
                }
            }

            //By age Search

            Console.WriteLine("Enter Age : ");
            string a = Console.ReadLine();
            if(a != "")
            {
                // Console.WriteLine(Convert.ToInt32(a));
                 int b= int.Parse(a);    //string into int
                foreach(int i in drivers.Keys)
                {
                    if (drivers[i].Age == b)
                    {
                        searchList.Add(drivers[i]);
                    }
                }
                //removal
                foreach(Driver driver in searchList)
                {
                    if(b != driver.Age)
                    {
                        searchList.Remove(driver);
                    }
                }
            }

            //By gender Search

            Console.WriteLine("Enter Gender : ");
            string gen = Console.ReadLine();

            if (gen != "")
            {
                foreach (int i in drivers.Keys)
                {
                    if (drivers[i].Gender == gen)
                    {
                        searchList.Add(drivers[i]);
                    }
                }

                //Remove
                foreach (Driver driver in searchList)
                {
                    if (gen != driver.Gender)
                    {
                        searchList.Remove(driver);
                    }
                }

            }
            //search by address
            Console.WriteLine("Enter Address : ");
            string add = Console.ReadLine();

            if (add != "")
            {
                foreach (int i in drivers.Keys)
                {
                    if (drivers[i].Address == add)
                    {
                        searchList.Add(drivers[i]);
                    }
                }

                //Remove
                foreach (Driver driver in searchList)
                {
                    if (add != driver.Address)
                    {
                        searchList.Remove(driver);
                    }
                }

            }

            //Serach By Vehicle Type

            Console.WriteLine("Enter Vehicle Type : ");
            string veh = Console.ReadLine();

            if (veh != "")
            {
                foreach (int i in drivers.Keys)
                {
                    if (drivers[i].Vehicle.Type == veh)
                    {
                        searchList.Add(drivers[i]);
                    }
                }

                //Remove
                foreach (Driver driver in searchList)
                {
                    if (veh != driver.Vehicle.Type)
                    {
                        searchList.Remove(driver);
                    }
                }

            }

            //by Model Search

            Console.WriteLine("Enter Vehicle Model : ");
            string mod = Console.ReadLine();

            if (mod != "")
            {
                foreach (int i in drivers.Keys)
                {
                    if (drivers[i].Vehicle.Model == mod)
                    {
                        searchList.Add(drivers[i]);
                    }
                }

                //Remove
                foreach (Driver driver in searchList)
                {
                    if (mod != driver.Vehicle.Model)
                    {
                        searchList.Remove(driver);
                    }
                }

            }

            //By license Plate Search

            Console.WriteLine("Enter Vehicle License Plate : ");
            string lic = Console.ReadLine();

            if (lic != "")
            {
                foreach (int i in drivers.Keys)
                {
                    if (drivers[i].Vehicle.LicensePlate == lic)
                    {
                        searchList.Add(drivers[i]);
                    }
                }

                //Remove
                foreach (Driver driver in searchList)
                {
                    if (lic != driver.Vehicle.LicensePlate)
                    {
                        searchList.Remove(driver);
                    }
                }

            }

            //DisplaY search List
            foreach(Driver driver in searchList)
            {
                Console.WriteLine("Name : " + driver.Name);
                Console.WriteLine("Age : " + driver.Age);
                Console.WriteLine("Gender : " + driver.Gender);
                Console.WriteLine("V.Type : " + driver.Vehicle.Type);
                Console.WriteLine("V.Model : " + driver.Vehicle.Model);
                Console.WriteLine("V.LicesePlate : " + driver.Vehicle.LicensePlate);
            }

        }

        /////Methhod
        ///Delete Driver
        public void removeDriver()
        {
            Console.WriteLine("Enter Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            bool flag = false;
            foreach(int i in drivers.Keys)
            {
                if(i == id)
                {
                    drivers.Remove(drivers[id]);
                    flag = true;
                    break;
                }
            }
            if(flag == false)
            {
                Console.WriteLine("......Driver does Not Exist.......");
            }
        }

    }
   
   
   
}