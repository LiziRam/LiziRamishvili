using System;

namespace Practical_3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your birth year:");
            int year = Convert.ToInt32(Console.ReadLine());
            int remainder = year % 12;
            string chineseYear;
            switch (remainder)
            {
                case 1:
                    chineseYear = "Rooster";
                    break;
                case 2:
                    chineseYear = "Dog";
                    break;
                case 3:
                    chineseYear = "Pig";
                    break;
                case 4:
                    chineseYear = "Rat";
                    break;
                case 5:
                    chineseYear = "Ox";
                    break;
                case 6:
                    chineseYear = "Tiger";
                    break;
                case 7:
                    chineseYear = "Rabbit";
                    break;
                case 8:
                    chineseYear = "Dragon";
                    break;
                case 9:
                    chineseYear = "Snake";
                    break;
                case 10:
                    chineseYear = "Horse";
                    break;
                case 11:
                    chineseYear = "Sheep";
                    break;

                default:
                    chineseYear = "Monkey";
                    break;
            }

            Console.WriteLine(year + " was a " + chineseYear + " year");
        }
    }
}

