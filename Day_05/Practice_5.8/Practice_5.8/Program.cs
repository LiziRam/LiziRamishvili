using System;

namespace Practice_5._8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Jagged Array

            int[][] jarray = new int[8][];
            for(int i = 0; i < jarray.Length; i++)
            {
                jarray[i] = new int[8];
            }

            for(int i = 0; i < jarray.Length; i++)
            {
                for(int j = 0; j < jarray[i].Length; j++)
                {
                   if(j <= i)
                    {
                        jarray[i][j] = 0;
                    }
                    else
                    {
                        jarray[i][j] = 1;
                    }
                }
            }

            for(int i = 0; i < jarray.Length; i++)
            {
                for(int j = 0; j < jarray[i].Length; j++)
                {
                    Console.Write(jarray[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            int dummy;
            for (int i = 0; i < 8 / 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dummy = jarray[i][j];
                    jarray[i][j] = jarray[7 - i][j];
                    jarray[7 - i][j] = dummy;
                }
            }

            for (int i = 0; i < jarray.Length; i++)
            {
                for (int j = 0; j < jarray[i].Length; j++)
                {
                    Console.Write(jarray[i][j] + " ");
                }
                Console.WriteLine();
            }


            //Multidimensional array
            
            //int[,] arrayBinary = new int[8, 8];
            //for(int i = 0; i < 8; i++)
            //{
            //    for(int j = 0; j < 8; j++)
            //    {
            //        if(j <= i)
            //        {
            //            arrayBinary[i, j] = 0;
            //        }
            //        else
            //        {
            //            arrayBinary[i, j] = 1;
            //        }

            //    }
            //}

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(arrayBinary[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine();

            //int dummy;
            //for (int i = 0; i < 8 / 2; i++)
            //{

            //    for (int j = 0; j < 8; j++)
            //    {
            //        dummy = arrayBinary[i, j];
            //        arrayBinary[i, j] = arrayBinary[7 - i, j];
            //        arrayBinary[7 - i, j] = dummy;
            //    }
            //}

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(arrayBinary[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}

