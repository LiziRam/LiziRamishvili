using System;

namespace Practice_10._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();

            Console.Write("Enter hours: ");
            clock.Hour = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter minutes: ");
            clock.Minute = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter seconds: ");
            clock.Second = Convert.ToInt32(Console.ReadLine());

            clock.GetCurrentTime();
            for (int i = 0; i < 4; i++)
            {
                clock.addSecond();
            }
            clock.GetCurrentTime();
            for(int i = 0; i < 3; i++)
            {
                clock.addSecond();
            }
            clock.addMinute();

            clock.GetCurrentTime();

            clock.subtractMinute();
            for (int i = 0; i < 3; i++)
            {
                clock.subtractSecond();
            }
            clock.GetCurrentTime();
            for (int i = 0; i < 4; i++)
            {
                clock.subtractSecond();
            }
            clock.GetCurrentTime();

        }
    }
}

