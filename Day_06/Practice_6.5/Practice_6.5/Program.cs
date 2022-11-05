using System;

namespace Practice_6._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = MakeArray();
            //int chosenNum = 5;
            int chosenNum = 6;
            bool contains = ContainsInt(arr,chosenNum);
            if (contains)
            {
                int factorial = GetFactorial(chosenNum);
                Console.WriteLine("Factorial of " + chosenNum + " is " + factorial);
            }
            else
            {
                Console.WriteLine("Number " + chosenNum + " was not found in the given array"); ;
            }
        }

        private static int[] MakeArray()
        {
            Console.Write("Enter size of array: ");
            int input = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[input];

            for (int i = 0; i < input; i++)
            {
                Console.Write("Enter integer for index " + i + ": ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;
        }

        private static bool ContainsInt(int[] arr, int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (num == arr[i])
                {
                    return true;
                }
            }
            return false; ;
        }

        private static int GetFactorial(int num)
        {
            int factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}

