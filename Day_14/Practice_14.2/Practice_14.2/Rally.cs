using System;
namespace Practice_14._2
{
    public class Rally : SportsCar
    {
        public Rally(int year, string category, string type, int speed, string rallyType) : base(year, category, type, speed)
        {
            RallyType = rallyType;
        }

        public string RallyType { get; set; }

        public override void Drive()
        {
            Console.WriteLine("Rally car driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"The type of this rally car is {RallyType}.");
        }
    }
}