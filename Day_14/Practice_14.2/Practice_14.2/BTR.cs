using System;
namespace Practice_14._2
{
    public class BTR : Military
    {
        public BTR(int year, string category, string type, int modelNumber) : base(year, category, type)
        {
            ModelNumber = "BTR-" + modelNumber;
        }

        public string ModelNumber { get; set; }

        public override void Drive()
        {
            Console.WriteLine("BTR driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"This BTR is {ModelNumber}.");
        }
    }
}

