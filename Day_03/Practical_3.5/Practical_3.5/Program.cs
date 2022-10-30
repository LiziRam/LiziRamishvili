using System;
using Internal;

namespace Practical_3._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your day of birth:");
            int day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your month of birth with capital letter:");
            string month = Console.ReadLine();

            //int monthNum = 0;
            string sign = "empty";

            switch (month)
            {
                case "January":
                    if (day < 20)
                    {
                        sign = "Capricorn";
                    }
                    else
                    {
                        sign = "Aquarius";
                    }
                    break;
                case "February":
                    if (day < 19)
                    {
                        sign = "Aquarius";
                    }
                    else
                    {
                        sign = "Pisces";
                    }
                    break;
                case "March":
                    if (day < 21)
                    {
                        sign = "Pisces";
                    }
                    else
                    {
                        sign = "Aries";
                    }
                    break;
                case "April":
                    if (day < 20)
                    {
                        sign = "Pisces";
                    }
                    else
                    {
                        sign = "Taurus";
                    }
                    break;
                case "May":
                    if (day < 21)
                    {
                        sign = "Taurus";
                    }
                    else
                    {
                        sign = "Gemini";
                    }
                    break;
                case "June":
                    if (day < 21)
                    {
                        sign = "Gemini";
                    }
                    else
                    {
                        sign = "Cancer";
                    }
                    break;
                case "July":
                    if (day < 23)
                    {
                        sign = "Cancer";
                    }
                    else
                    {
                        sign = "Leo";
                    }
                    break;
                case "August":
                    if (day < 23)
                    {
                        sign = "Leo";
                    }
                    else
                    {
                        sign = "Virgo";
                    }
                    break;
                case "September":
                    if (day < 23)
                    {
                        sign = "Virgo";
                    }
                    else
                    {
                        sign = "Libra";
                    }
                    break;
                case "October":
                    if (day < 23)
                    {
                        sign = "Libra";
                    }
                    else
                    {
                        sign = "Scorpio";
                    }
                    break;
                case "November":
                    if (day < 22)
                    {
                        sign = "Scorpio";
                    }
                    else
                    {
                        sign = "Sagittarius";
                    }
                    break;
                case "December":
                    if (day < 22)
                    {
                        sign = "Sagittarius";
                    }
                    else
                    {
                        sign = "Capricorn";
                    }
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            if (sign != "empty")
            {
                Console.WriteLine(day + " " + month + " is " + sign);
            }
        }
    }
}

