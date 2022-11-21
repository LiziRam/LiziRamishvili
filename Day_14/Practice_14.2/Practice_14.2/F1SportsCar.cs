using System;
namespace Practice_14._2
{
    public class F1SportsCar : SportsCar
    {
        public F1SportsCar(int year, string category, string type, int speed, string engineManufacturer) : base(year, category, type, speed)
        {
            EngineManufacturer = engineManufacturer;
        }
        public string EngineManufacturer { get; set; }

        public override void Drive()
        {
            Console.WriteLine("F1 race car driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"The engine for this F1 car is provided by {EngineManufacturer}.");
        }
    }
}

