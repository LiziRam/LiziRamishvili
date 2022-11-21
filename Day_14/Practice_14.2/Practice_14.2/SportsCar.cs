using System;
namespace Practice_14._2
{
    public class SportsCar : Vehicle
    {
        public SportsCar(int year, string category, string type, int speed) : base(year, category)
        {
            Type = type;
            Speed = speed;
        }

        public string Type { get; set; }
        public static double Speed { get; set; }

        public override void Drive()
        {
            Console.WriteLine("Driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"Type of the vehicle is {Type}.");

        }

        public override void Reasoning()
        {
            Console.WriteLine("Used for performance in high speed.");
            Console.WriteLine($"The speed of this car is {Speed}mph.");
        }
    }
}

