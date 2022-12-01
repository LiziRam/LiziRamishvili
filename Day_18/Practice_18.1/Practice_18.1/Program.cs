using System;

namespace Practice_18._1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedItem<string> testLinked = new LinkedItem<string>();
            for(int i = 0; i < 5; i++)
            {
                Console.Write("Enter a random name: ");
                testLinked[i] = Console.ReadLine();
            }

            Console.WriteLine("Elements of our Linked item are: ");
            for (int i = 0; i < testLinked.ElemCount; i++)
            {
                Console.WriteLine(testLinked[i]);
            }

            Console.WriteLine("Enter a new name: ");
            testLinked[testLinked.ElemCount] = Console.ReadLine();
            Console.WriteLine($"Last element of our Linked Item is {testLinked[testLinked.ElemCount - 1]}");

            //try
            //{
            //    Console.WriteLine(testLinked[testLinked.ElemCount]);
                  //max index is Elemcount - 1, Should return OutOfLinkedItemBoundsException
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}

