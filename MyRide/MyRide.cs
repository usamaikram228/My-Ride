//// See https://aka.ms/new-console-template for more information

using System;
using ClassLibraryDriver;
using ClassLibrary3;
using ClassLibraryVehicle;
using ClassLibraryAdmin;
using ClassLibraryRide;
using ClassLibraryPasssenger;


//Ride re = new Ride();
//re.StartLocation.setLocation(2, 4);
//re.EndLocation.setLocation(7, 5);
//re.Driver.Vehicle.Type = "car";
//Console.WriteLine(re.calculatePrice());


Console.WriteLine("--------------------------------------");
Console.WriteLine("         Welcome To MyRide   ");
Console.WriteLine("--------------------------------------");


int option;
Admin admin = new Admin();
do
{
    Console.WriteLine("1: Book a Ride");
    Console.WriteLine("2: Enter as Driver");
    Console.WriteLine("3: Enter as Admin");

    Console.Write("Press 1 to 3 to select an option : ");
    option = Convert.ToInt32(Console.ReadLine());

    

    if(option == 1)
    {
        Ride rider = new Ride();

        Console.Write("Enter Name : ");
        rider.Passenger.Name = Console.ReadLine();

        Console.Write("Enter Phone Number : ");
        rider.Passenger.PhoneNo = Console.ReadLine();

        Console.Write("Enter Starting Location : ");
        string input = Console.ReadLine();
        string[] a = input.Split(",");
        float startlan = (float)Convert.ToDouble(a[0]);
        float startLong = (float)Convert.ToDouble(a[1]);
        //Console.WriteLine(startlan);
        //Console.WriteLine(startLong);
        // Console.WriteLine(a[0]);


        rider.StartLocation.setLocation(startlan, startLong);

        Console.Write("Enter Ending Location : ");
        string inputEnd = Console.ReadLine();
        string[] e = inputEnd.Split(",");
        // Console.WriteLine(e);
        float endLan = (float)Convert.ToDouble(e[0]);
        float endLon = (float)Convert.ToDouble(e[1]);
        // Console.WriteLine(endLan);
        // Console.WriteLine(endLon);
        rider.EndLocation.setLocation(endLan, endLon);

        rider.getLocation(rider.StartLocation, rider.EndLocation);


        Console.WriteLine("Enter Vehicle Type : ");
        string type = Console.ReadLine();


        rider.Driver.Vehicle.Type = type;
        Console.WriteLine(rider.Driver.Vehicle.Type);

        Console.WriteLine("-------Thank You-------");
        Console.WriteLine("Price for this ride is : " + rider.calculatePrice());

        Console.Write("Enter Y for booking and N for cancel : ");
        string y = Console.ReadLine();

        if (y == "Y")
        {

            //List of available drivers
            List<Driver> driversList = new List<Driver>();
            foreach (int i in admin.Drivers.Keys)
            {
                if (admin.Drivers[i].Availability == true && admin.Drivers[i].Vehicle.Type == type)
                {
                    driversList.Add(admin.Drivers[i]);
                }
            }

            //driver available
            if (driversList.Count == 0)
            {
                Console.Write("No driver available");

            }
            else
            {


                //Short Distance Avialable Driver

                float lanTemp = driversList[0].CurrentLocation.Latitude - rider.StartLocation.Latitude;
                double powTemp = Math.Pow(lanTemp, 2);
                float lonTemp = driversList[0].CurrentLocation.Longitude - rider.StartLocation.Longitude;
                double powTemp2 = Math.Pow(lonTemp, 2);
                double distance = powTemp2 + powTemp;
                distance = Math.Sqrt(distance);

                double shortdistance = distance;
                Console.WriteLine("aaaa"+distance);
                Driver shortDistanceAvailableDriver = new Driver();
                foreach (Driver d in driversList)
                {
                    lanTemp = d.CurrentLocation.Latitude - rider.StartLocation.Latitude;
                    powTemp = Math.Pow(lanTemp, 2);
                    lonTemp = d.CurrentLocation.Longitude - rider.StartLocation.Longitude;
                    powTemp2 = Math.Pow(lonTemp, 2);
                    distance = powTemp2 + powTemp;
                    distance = Math.Sqrt(distance);

                    //Console.WriteLine(distance);
                    //Console.WriteLine(d.Name);
                    if (distance <= shortdistance)
                    {
                        //Console.WriteLine("askjd");
                        shortdistance = distance;
                        shortDistanceAvailableDriver = d;
                    }
                }
                //Console.WriteLine(shortdistance);
                //Console.WriteLine(shortDistanceAvailableDriver.Name);
                //assignments
                rider.assignDriver(shortDistanceAvailableDriver);
                rider.assignPassenger(rider.Passenger);


                Console.WriteLine("Happy Travels----");

                //Rating
                Console.Write("Give Rating out of 5: ");
                int r = Convert.ToInt32(Console.ReadLine());
                rider.giveRating(r);
            }
        }
        else if (y == "N")
        {
            Environment.Exit(0);
        }
        else
        {
            Environment.Exit(0);
        }

    }
    else if(option == 2)
    {
        Console.Write("Enter Id : ");
        int ide = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name : ");
        string nameInput = Console.ReadLine();

        Driver dri = new Driver();

        bool flag = false;
        foreach (int z in admin.Drivers.Keys)
        {
            if (z == ide)
            {
                Console.WriteLine("Hello " + admin.Drivers[z].Name);
                dri = admin.Drivers[z];
                flag = true;
                break;

            }
        }
        if (flag == false)
        {
            Console.WriteLine("Driver is not Registered ");
            Environment.Exit(0);
        }
        else
        {
            Console.Write("Enter Current Location : ");
            string inputCurLocation = Console.ReadLine();
            string[] l = inputCurLocation.Split(",");
            float curlan = float.Parse(l[0]);
            float curLong = float.Parse(l[1]);

            int option2;

            do
            {
                Console.WriteLine("1:Change Availability");
                Console.WriteLine("2:Change Location");
                Console.WriteLine("3:Exit");

                Console.Write("Selecet Option : ");
                option2 = Convert.ToInt32(Console.ReadLine());
                if (option2 == 1)
                {
                    dri.updateAvailability();
                }
                else if (option2 == 2)
                {
                    Console.WriteLine("Enter new loaction : ");
                    string inputNewLocation = Console.ReadLine();
                    string[] newLoc = inputNewLocation.Split(",");
                    float newLan = float.Parse(newLoc[0]);
                    float newLon = float.Parse(newLoc[1]);
                    dri.updateLocation(newLan, newLon);
                }

            } while (option2 != 3);
           
            //switch (option2)
            //{
            //    case 1:
            //        dri.updateAvailability();    //Change availabilty
            //        break;
            //    case 2:

            //        dri.updateLocation(curlan, curLong);
            //        break;
            //    case 3:
            //        Environment.Exit(0);
            //        break;
            //}

        }

        }
    else if(option == 3)
    {
        int option3;
        do
        {
            Console.WriteLine("1:Add Driver");
            Console.WriteLine("2:Remove Driver");
            Console.WriteLine("3:Update Driver");
            Console.WriteLine("4:Search Driver");
            Console.WriteLine("5:Exit as admin");
            Console.Write("Select Option : ");
             option3 = Convert.ToInt32(Console.ReadLine());
            if (option3 == 1)
            {
                admin.addDriver(120);
            }
            else if (option3 == 2)
            {
                admin.removeDriver();
            }
            else if (option3 == 3)
            {
                admin.updateDriver();
            }
            else if (option3 == 4)
            {
                admin.searchDriver();
            }
        } while (option3 != 5);
       

    }

} while (option > 1 || option < 4);

