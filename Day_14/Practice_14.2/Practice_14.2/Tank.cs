using System;
namespace Practice_14._2
{
    public class Tank : Military
    {
        public Tank(int year, string category, string type, string weightType) : base(year, category, type)
        {
            WeightType = weightType;
        }

        public string WeightType { get; set; }

        public override void Drive()
        {
            Console.WriteLine("Tank driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"This tank is {WeightType}.");
        }
    }
}

