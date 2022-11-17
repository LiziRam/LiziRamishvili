using System;
namespace Practice_14._2
{
    public class PublicTransport : Vehicle
    {
        public PublicTransport(int year, string category, string type) : base(year, category)
        {
            Type = type;
        }

        public string Type { get; set; }

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
            Console.WriteLine("Used for public transportation.");
        }
    }
}

