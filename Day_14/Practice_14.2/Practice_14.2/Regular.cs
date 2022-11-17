using System;
namespace Practice_14._2
{
    public class Regular : Vehicle
    {
        public Regular(int year, string category, int numberOfSeats, string type) : base(year, category)
        {
            Type = type;
            NumberOfSeats = numberOfSeats;
        }

        public string Type { get; set; }
        public static int NumberOfSeats { get; set; }

        public override void Drive()
        {
            Console.WriteLine("Driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"Type of the vehicle is {Type}.");
            Console.WriteLine($"Number of seats in this vehicle is {NumberOfSeats}.");
        }

        public override void Reasoning()
        {
            Console.WriteLine("Used in daily life.");
        }
    }
}

