using System;
namespace Practice_14._2
{
    public class Bus : PublicTransport
    {
        public Bus(int year, string category, string type, string busType) : base(year, category, type)
        {
            BusType = busType;
        }

        public string BusType { get; set; }

        public override void Drive()
        {
            Console.WriteLine("Bus driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"This bus is a {BusType}.");
        }
    }
}

