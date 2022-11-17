using System;

namespace Practice_14._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string category = "";
            string type = "";
            Console.WriteLine("Vehicle categories: \n1. Military \n2. Regular \n3. Public transport \n4. Sports car");
            Console.Write("Choose the category of a vehicle (by number): ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (n)
            {
                case 1:
                    Console.WriteLine("Category types: \n1. Tank \n2. BTR");
                    break;
                case 2:
                    Console.WriteLine("Category types: \n1. Sedan \n2. Minivan \n3. Motorcycle");
                    break;
                case 3:
                    Console.WriteLine("Category types: \n1. Bus \n2. Tram");
                    break;
                case 4:
                    Console.WriteLine("Category types: \n1. F1 \n2. Rally \n3. Offroad");
                    break;
                default:
                    Console.WriteLine("Not a category");
                    break;
            }

            Console.Write("Choose the type of a category (by number): ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Enter a recommended release year for a vehicle: ");
            int year = Convert.ToInt32(Console.ReadLine());


            if (n == 1)
            {
                category = "Military";

                if(n2 == 1)
                {
                    type = "Tank";
                    Console.Write("Enter the weight type of a tank: "); //light, medium, heavy
                    string weightType = Console.ReadLine();
                    Tank tank = new Tank (year, category, type, weightType);
                    tank.GetBasicInfo();
                    tank.Reasoning();
                    tank.Drive();
                }

                if(n2 == 2)
                {
                    type = "BTR";
                    Console.Write("Enter a model number of a BTR: "); //40, 50, 60...
                    int modelNum = Convert.ToInt32(Console.ReadLine());
                    BTR btr = new BTR(year, category, type, modelNum);
                    btr.GetBasicInfo();
                    btr.Reasoning();
                    btr.Drive();
                }
            }

            if(n == 2)
            {
                category = "Regular";

                if (n2 == 1)
                {
                    type = "Sedan";
                    int seats = 5;
                    Console.Write("Enter the style of a sedan: "); //convertible, fastback, hardtop
                    string variation = Console.ReadLine();
                    Sedan sedan = new Sedan(year, category, seats, type, variation);
                    sedan.GetBasicInfo();
                    sedan.Reasoning();
                    sedan.Drive();
                }

                if(n2 == 2)
                {
                    type = "Minivan";
                    int seats = 8;
                    Console.Write("Enter the manufacturer of this minivan: "); //Honda, Kia, Toyota
                    string manufacturer = Console.ReadLine();
                    Minivan minivan = new Minivan(year, category, seats, type, manufacturer);
                    minivan.GetBasicInfo();
                    minivan.Reasoning();
                    minivan.Drive();
                }

                if(n2 == 3)
                {
                    type = "Motorcycle";
                    int seats = 1;
                    Console.Write("Enter the type of a motorcycle: "); //standard, cruising, touring
                    string motorcycleType = Console.ReadLine();
                    Motorcycle mot = new Motorcycle(year, category, seats, type, motorcycleType);
                    mot.GetBasicInfo();
                    mot.Reasoning();
                    mot.Drive();
                }
            }

            if(n == 3)
            {
                category = "Public Transport";

                if (n2 == 1)
                {
                    type = "Bus";
                    Console.Write("Enter the type of a bus: "); //School Bus, Coach
                    string busType = Console.ReadLine();
                    Bus bus = new Bus(year, category, type, busType);
                    bus.GetBasicInfo();
                    bus.Reasoning();
                    bus.Drive();
                }

                if (n2 == 2)
                {
                    type = "Tram";
                    Console.Write("Enter the type of a tram: "); //Articulated, Double-decker
                    string tramType = Console.ReadLine();
                    Tram tram = new Tram(year, category, type, tramType);
                    tram.GetBasicInfo();
                    tram.Reasoning();
                    tram.Drive();
                }
            }

            if (n == 4)
            {
                category = "Sports Car";

                if (n2 == 1)
                {
                    type = "F1 car";
                    int speed = 224;
                    Console.Write("Enter the manufacturer of the engine: "); //Honda, Ferrari, Mercedes
                    string engineManufacturer = Console.ReadLine();
                    F1SportsCar f1Car = new F1SportsCar(year, category, type, speed, engineManufacturer);
                    f1Car.GetBasicInfo();
                    f1Car.Reasoning();
                    f1Car.Drive();
                }

                if (n2 == 2)
                {
                    type = "Rally";
                    int speed = 78;
                    Console.Write("Enter the type of a rally car: "); //Road-rally, OffRoad-Rally, Touring Assembly
                    string rallyType = Console.ReadLine();
                    Rally rally = new Rally(year, category, type, speed, rallyType);
                    rally.GetBasicInfo();
                    rally.Reasoning();
                    rally.Drive();
                }

                if (n2 == 3)
                {
                    type = "OffRoad";
                    int speed = 55;
                    Console.Write("Enter the type of a motorcycle: "); //Jeep, Toyota, Suzuki
                    string brand = Console.ReadLine();
                    OffRoad offr = new OffRoad(year, category, type, speed, brand);
                    offr.GetBasicInfo();
                    offr.Reasoning();
                    offr.Drive();
                }
            }
        }
    }
}

