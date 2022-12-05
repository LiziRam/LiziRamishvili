using System;
using System.IO;
using System.Collections.Generic;


namespace Practice_19._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/Users/liziramishvili/Desktop/LiziRamishvili/Day_19/Practice_19.1/Practice_19.1/Cities.txt";
         
            StreamReader sr;
            try
            {
                sr = new StreamReader(path);
            }
            catch(Exception ex)
            {
                LogException(ex.Message);
                throw;
            }

            List<City> cities = new List<City>();
            string[] info = new string[5];
            List<string> countryNames = new List<string>(); 
            City city; 
            double area;
            int population;
            bool isCapital;
            string country; 

            string currLine = sr.ReadLine();
            while(currLine != null)
            {
                if(currLine != "")
                {
                    info = currLine.Split('|'); //City, Area, Population, bool, Country
                    area = Convert.ToDouble(info[1]);
                    population = Convert.ToInt32(info[2]);
                    isCapital = Convert.ToBoolean(info[3]);
                    country = info[4];
                    city = new City(info[0], area, population, info[4], isCapital);
                    cities.Add(city);

                    if (!countryNames.Contains(country))
                    {
                        countryNames.Add(country);
                    } 
                }
                currLine = sr.ReadLine();
            }
            sr.Close();

            List<Country> countries = new List<Country>();
            foreach (string currCountry in countryNames)
            {
                List<City> countryCities = new List<City>();
                int capitalCount = 0;
                foreach(City currCity in cities)
                {
                    if(currCountry == currCity.Country)
                    {
                        if (currCity.isCapital)
                        {
                            capitalCount++;
                            if(capitalCount > 1)
                            {
                                LogException("Capital Exception: Country must have a single capital.");
                                throw new CountryMustHaveSingleCapitalException();
                            }
                            countryCities.Insert(0, currCity);
                        }
                        else
                        {
                            countryCities.Add(currCity);
                        }
                    }
                }
                Country c = new Country(currCountry, countryCities);
                countries.Add(c);
            }
            
            Console.WriteLine("1. Search Country \n2. Search City");
            Console.Write("Enter 1 or 2 depending on your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice != 1 && choice != 2)
            {
                LogException("Invalid input: choice should have been 1 or 2");
                throw new InvalidInputException("Choice should have been 1 or 2");
            }
            if(choice == 1)
            {
                Console.Write("Enter name of the country of your choice (start with a capital letter): ");
                string chosenCountry = Console.ReadLine();
                Country chosen1 = null;
                bool foundCntr = false;
                foreach(var cntr in countries)
                {
                    if(chosenCountry == cntr.Name)
                    {
                        foundCntr = true;
                        chosen1 = cntr;
                    }
                }
                if (!foundCntr)
                {
                    LogException("Invalid input: entered country name is not valid.");
                    throw new InvalidInputException("Entered country name is not valid.");
                }
                Console.WriteLine($"Country: {chosen1.Name}, Area: {chosen1.Area}, Population: {chosen1.Population}");
                Console.WriteLine($"Cities: ");
                for(int i = 0; i < chosen1.Count; i++)
                {
                    if(i == 0)
                    {
                        Console.WriteLine($"1. {chosen1[i]} (isCapital)");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {chosen1[i]}");
                    }
                }
            }
            else if(choice == 2)
            {
                Console.Write("Enter name of the city of your choice (start with a capital letter): ");
                string chosenCity = Console.ReadLine();
                City chosen2 = null;
                bool foundCt = false;
                foreach(var ct in cities)
                {
                    if(chosenCity == ct.Name)
                    {
                        foundCt = true;
                        chosen2 = ct;
                    }
                }

                if (!foundCt)
                {
                    LogException("Invalid input: entered city name is not valid.");
                    throw new InvalidInputException("Entered city name is not valid.");
                }

                Console.WriteLine($"City: {chosen2.Name}, Area: {chosen2.Area}, Population: {chosen2.Population}");
                Console.WriteLine($"Country: {chosen2.Country}, isCapital - {chosen2.isCapital}");
            }
        }
        private static void LogException(string message)
        {
            using (StreamWriter sw = new StreamWriter("/Users/liziramishvili/Desktop/LiziRamishvili/Day_19/Practice_19.1/Practice_19.1/Logs.txt"))
            {
                sw.WriteLine(message);
            }
        }
    }
}

