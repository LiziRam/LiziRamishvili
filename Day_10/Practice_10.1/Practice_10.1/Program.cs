using System;

namespace Practice_10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Cat object...");
            Cat kitty = new Cat();

            Console.Write("Enter name: ");
            kitty.Name = Console.ReadLine();

            Console.Write("Enter breed: ");
            kitty.Breed = Console.ReadLine();

            Console.Write("Enter age: ");
            kitty.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter sex: ");
            kitty.Sex = Console.ReadLine();

            Console.WriteLine("Cat object created.");

            Console.Write("Enter food weight in grams: ");
            int food = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine ($"{kitty.Name} start eating.");
            kitty.Eat(food);
            Console.WriteLine($"{kitty.Name} finished eating.");

            Console.Write("Enter meowing count: ");
            int meowing = Convert.ToInt32(Console.ReadLine());
            kitty.Meowing(meowing);

        }
    }
}

