using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Practice_24._1
{
    class Program
    {
        //static string customerInfo = "/Users/liziramishvili/Desktop/LiziRamishvili/Day_24/Practice_24.1/Practice_24.1/Customers.txt";
        //static string OrderInfo = "/Users/liziramishvili/Desktop/LiziRamishvili/Day_24/Practice_24.1/Practice_24.1/Orders.txt";

        static void Main(string[] args)
        {
            string customerInfo = "/Users/liziramishvili/Desktop/LiziRamishvili/Day_24/Practice_24.1/Practice_24.1/Customers.txt";
            string OrderInfo = "/Users/liziramishvili/Desktop/LiziRamishvili/Day_24/Practice_24.1/Practice_24.1/Orders.txt";

            List<Customer> customers = new List<Customer>();
            List<Order> orders = new List<Order>();

            List<int> CustomerId = new List<int>();
            List<string> CustomerName = new List<string>();

            StreamReader srCustomerInfo;
            try
            {
                srCustomerInfo = new StreamReader(customerInfo);
            }
            catch
            {
                throw;
            }
            ReadInfo(srCustomerInfo, customers, null);

            StreamReader srOrderInfo;
            try
            {
                srOrderInfo = new StreamReader(OrderInfo);
            }
            catch
            {
                throw;
            }
            ReadInfo(srOrderInfo, null, orders);
            
            //1
            var orderIds = from o in orders
                           select o.CustomerId;

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"CustomerId - {i}, OrderCount - {orderIds.Count(x => x == i)}");
            }

            Console.WriteLine();
            //2
            var orderPrices = from o in orders
                              select new { o.CustomerId, o.Price };

            for (int i = 1; i <= 5; i++)
            {
                var currList = from o in orders
                               where o.CustomerId == i
                               select o.Price;
                Console.WriteLine($"CustomerId - {i}, SumAmount - {currList.Sum()}");
            }

            Console.WriteLine();
            //3
            for (int i = 1; i <= 5; i++)
            {
                var currList = from o in orders
                               where o.CustomerId == i
                               select o.Price;
                Console.WriteLine($"CustomerId - {i}, MinAmount - {currList.Min()}");
            }

            Console.WriteLine();
            //4
            var customerFrequency = from o in orders
                                    group o by o.CustomerId;

            foreach (var group in customerFrequency)
            {
                if (group.Count() > 1)
                {
                    Console.WriteLine($"CustomerId - {group.Key}, OrderCount - {group.Count()}");
                }
            }

            Console.WriteLine();
            //5
            int moreThan10 = 0;
            foreach (var group in customerFrequency)
            {
                double avg = group.Average(x => x.Price);
                if(avg > 2.9)
                {
                    Console.WriteLine($"CustomerId - {group.Key}, AvgAmount - {avg}");
                    moreThan10++;
                }
            }
            if (moreThan10 == 0)
            {
                Console.WriteLine("None of those customers average orders are more than 10.");
            }
        }

        static void ReadInfo(StreamReader sr, List<Customer> c, List<Order> o)
        {
            string currLine = sr.ReadLine();
            while (currLine != null)
            {
                if (currLine != "")
                {
                    string[] info = currLine.Split('|');
                    if(c != null)
                    {
                        int id = Convert.ToInt32(info[0]);
                        string name = info[1];
                        Customer cNew = new Customer(id, name);
                        c.Add(cNew);
                    }
                    else
                    {
                        int id = Convert.ToInt32(info[0]); 
                        string date = info[1];
                        string prod = info[2];
                        double price = Convert.ToDouble(info[3]);
                        int customer = Convert.ToInt32(info[4]);
                        Order oNew = new Order(id, date, prod, price, customer);
                        o.Add(oNew);
                    }
                }
                currLine = sr.ReadLine();
            }
            sr.Close();
        }
    }
}

