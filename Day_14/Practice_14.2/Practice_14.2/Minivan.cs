using System;
namespace Practice_14._2
{
    public class Minivan : Regular
    {

        public Minivan(int year, string category, int numberOfSeats, string type, string manufacturer) : base(year, category, numberOfSeats, type)
        {
            Manufacturer = manufacturer;
        }

        public string Manufacturer { get; set; }

        public override void Drive()
        {
            Console.WriteLine("Minivan driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"Manufacturer of this minivan is {Manufacturer}.");
        }
    }
}

