using System;
namespace Practice_14._2
{
    public class Sedan : Regular
    {

        public Sedan(int year, string category, int numberOfSeats, string type,  string variation) : base(year, category, numberOfSeats, type)
        {
            Variation = variation;
        }

        public string Variation { get; set; }

        public override void Drive()
        {
            Console.WriteLine("Sedan driving...");
        }

        public override void GetBasicInfo()
        {
            base.GetBasicInfo();
            Console.WriteLine($"Style variation of this Sedan is {Variation}.");
        }
    }
}

