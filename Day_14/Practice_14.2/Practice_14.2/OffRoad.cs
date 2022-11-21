using System;
namespace Practice_14._2
{
    public class OffRoad : SportsCar
    {
        public OffRoad(int year, string category, string type, int speed, string brand) : base(year, category, type, speed)
        {
            Brand = brand;
        }
        public string Brand { get; set; }

        public override void Drive()
        {
            Console.WriteLine("OffRoad car driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"This offroad car is a {Brand}.");
        }
    }
}

