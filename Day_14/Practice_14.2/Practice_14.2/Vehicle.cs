using System;
namespace Practice_14._2
{
    public abstract class Vehicle
    {
        public Vehicle(int year, string category)
        {
            ReleaseYear = year;
            Category = category;
        }

        public int ReleaseYear { get; set; }
        public string Category { get; set; }

        public abstract void Drive();

        public virtual void GetBasicInfo()
        {
            Console.WriteLine($"Release year of the vehicle is {ReleaseYear}. \nCategory of the vehicle is {Category}.");
        }

        public virtual void Reasoning()
        {
            Console.WriteLine("Used for transporting.");
        }
    }
}

