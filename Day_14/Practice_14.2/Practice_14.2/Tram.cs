using System;
namespace Practice_14._2
{
    public class Tram : PublicTransport
    {
        public Tram(int year, string category, string type, string tramType) : base(year, category, type)
        {
            TramType = tramType;
        }

        public string TramType { get; set; }

        public override void Drive()
        {
            Console.WriteLine("Tram driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"This tram is a {TramType}.");
        }
    }
}

