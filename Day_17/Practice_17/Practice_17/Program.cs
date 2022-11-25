using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Practice_17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's assemble an ArrayList.");
            ArrayList arrList = new ArrayList();
            Console.WriteLine("Enter 5 strings: ");
            for (int i = 0; i < 5; i++)
            {
                arrList.Add(Console.ReadLine());
            }
            Console.WriteLine("Now, enter 5 integers: ");
            for (int i = 0; i < 5; i++)
            {

                arrList.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.Write("Now, enter a boolean. T for true, anything else for false: ");
            string boolString = Console.ReadLine();
            bool enteredBool = false;
            if (boolString == "T" || boolString == "t")
            {
                enteredBool = true;
            }
            arrList.Add(enteredBool);
            Console.WriteLine($"Enter an index from 0 to {arrList.Count - 1} to erase an element of an ArrayList: ");
            arrList.RemoveAt(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"Capatity of our ArrayList is {arrList.Capacity}. \nNumber of elements in our ArrayList is {arrList.Count}.");
            Console.WriteLine("These are the elements of our arrayList: ");
            for (int i = 0; i < arrList.Count; i++)
            {
                Console.Write(arrList[i] + " ");
            }
            Console.WriteLine();
            Console.Write("If you want to clear the arrayList, enter C: ");
            string charStr = Console.ReadLine();
            if (charStr == "C" || charStr == "c")
            {
                arrList.Clear();
            }
            Console.WriteLine($"Capatity of our ArrayList is {arrList.Capacity}. \nNumber of elements in our ArrayList is {arrList.Count}.");

            Console.WriteLine();
            List<string> names = new List<string>();
            Console.WriteLine("Enter 5 names: ");
            for (int i = 0; i < 5; i++)
            {
                names.Add(Console.ReadLine());
            }
            Console.Write("If you want to sort the list, enter S: ");
            string charStr2 = Console.ReadLine();
            if (charStr2 == "S" || charStr2 == "s")
            {
                names.Sort();
                Console.WriteLine("This is how sorted list looks like: ");
                foreach (var elem in names)
                {
                    Console.WriteLine(elem);
                }
            }
            Console.WriteLine("Enter one name from the list and the program will return its index in a sorted list: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Index of {name} is {names.IndexOf(name)}");
            Console.WriteLine("Enter a name which you want to insert in the list. Enter an index where you want to insert it: ");
            Console.Write("Name: ");
            string newName = Console.ReadLine();
            Console.Write("Index: ");
            int index = Convert.ToInt32(Console.ReadLine());
            names.Insert(index, newName);
            Console.WriteLine("This is how the list looks like at the moment: ");
            foreach (var elem in names)
            {
                Console.WriteLine(elem);
            }

            Console.WriteLine();
            Dictionary<int, string> codeNames = new Dictionary<int, string>();
            Console.WriteLine("Enter names and unique codes for each name: ");
            string currName = "";
            int code;
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Name: ");
                currName = Console.ReadLine();
                Console.Write("Code: ");
                code = Convert.ToInt32(Console.ReadLine());
                codeNames.Add(code, currName);
            }
            Console.WriteLine("This is how our key-value pairs look like: ");
            foreach (var elem in codeNames)
            {
                Console.WriteLine(elem);
            }
            Console.Write("Enter a key of a name you want to remove from the dictionary: ");
            int key = Convert.ToInt32(Console.ReadLine());
            codeNames.Remove(key);
            Console.Write("Enter a code to check if the dictionary contains it as a key: ");
            int keyCode = Convert.ToInt32(Console.ReadLine());
            bool doesContain = codeNames.ContainsKey(keyCode);
            if (doesContain)
            {
                Console.WriteLine($"Dictionary contains a key {keyCode}, its value is {codeNames[keyCode]}");
            }
            else
            {
                Console.Write($"Dictionary does not contain a key {keyCode}, enter a value to add it: ");
                codeNames.Add(keyCode, Console.ReadLine());
            }
            Console.WriteLine("This is how our dictionary looks like: ");
            foreach (var elem in codeNames)
            {
                Console.WriteLine(elem);
            }

            Console.WriteLine();
            Console.WriteLine("Enter numbers to push into stack: ");
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Number {i + 1}: ");
                numbers.Push(Convert.ToInt32(Console.ReadLine()));
            }
            Console.Write("You can \n1. Look at the last number \n2. Look at the last number and erase it \nWrite 1 or 2 based on the option you prefer: ");
            int option = Convert.ToInt32(Console.ReadLine());
            int lastNumber = 0;
            if (option == 1)
            {
                lastNumber = numbers.Peek();
            }
            if (option == 2)
            {
                lastNumber = numbers.Pop();
            }
            Console.WriteLine($"Last number of the stack was {lastNumber}");
            Console.WriteLine("This is how our stack look like: ");
            foreach (var elem in numbers)
            {
                Console.WriteLine(elem);
            }

            Console.WriteLine();
            Queue<string> queueNames = new Queue<string>();
            Console.WriteLine("Enter names to enqueue: ");
            string queueName = "";
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Name: ");
                queueName = Console.ReadLine();
                queueNames.Enqueue(queueName);
            }
            Console.WriteLine("This is how our queue looks like: ");
            foreach (var elem in queueNames)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("Let's copy our queue to an array;");
            string[] queue = new string[queueNames.Count];
            queueNames.CopyTo(queue, 0);
            Console.WriteLine("Now let's dequeue 2 elements of our queue.");
            queueNames.Dequeue();
            queueNames.Dequeue();
            Console.WriteLine($"Queue currently has {queueNames.Count} elemets, while the array has {queue.Length} elements.");
            Console.WriteLine("These are the elements of our array: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(queue[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Enter names and ages of 3 people: ");
            string tupleName = "";
            int age = 0;
            bool isAdult = false;

            Console.Write("Name: ");
            tupleName = Console.ReadLine();
            Console.Write("Age: ");
            age = Convert.ToInt32(Console.ReadLine());
            if (age >= 18)
            {
                isAdult = true;
            }
            Tuple<int, string, bool> person1 = new Tuple<int, string, bool>(age, tupleName, isAdult);
            isAdult = false;

            Console.Write("Name: ");
            tupleName = Console.ReadLine();
            Console.Write("Age: ");
            age = Convert.ToInt32(Console.ReadLine());
            if (age >= 18)
            {
                isAdult = true;
            }
            Tuple<int, string, bool> person2 = Tuple.Create(age, tupleName, isAdult);
            isAdult = false;

            Console.Write("Name: ");
            tupleName = Console.ReadLine();
            Console.Write("Age: ");
            age = Convert.ToInt32(Console.ReadLine());
            if (age >= 18)
            {
                isAdult = true;
            }
            Tuple<int, string, bool> person3 = new Tuple<int, string, bool>(age, tupleName, isAdult);

            Console.WriteLine("Are they adults?");
            Console.WriteLine($"{person1.Item2} - {person1.Item3} \n{person2.Item2} - {person2.Item3} \n{person3.Item2} - {person3.Item3}");

            Console.WriteLine();
            Console.WriteLine($"Person 1 and Person 2 have same parameters - {person1.Equals(person2)}");
            Console.WriteLine($"Person 1 and Person 3 have same parameters - {person1.Equals(person3)}");
            Console.WriteLine($"Person 2 and Person 3 have same parameters - {person2.Equals(person3)}");
        }
    }
}

