using System;
namespace Practice_14._2
{
    public class Motorcycle : Regular
    {
        public Motorcycle(int year, string category, int numberOfSeats, string type, string motorcycleType) : base(year, category, numberOfSeats, type)
        {
            MotorcycleType = motorcycleType;
        }

        public string MotorcycleType { get; set; }

        public override void Drive()
        {
            Console.WriteLine("Motorcycle driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"Type of this motorcycle is {MotorcycleType}.");
        }
    }
}

