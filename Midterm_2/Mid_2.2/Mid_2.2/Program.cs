using System;
using System.Collections.Generic;
using System.IO;

namespace Mid_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/Users/liziramishvili/Desktop/LiziRamishvili/Midterm_2/Mid_2.2/Mid_2.2/Words.txt";
            List<string> words = new List<string>();
            StreamReader sr;
            try
            {
                sr = new StreamReader(path);
            }
            catch (Exception)
            {
                throw;
            }
            string currWord = sr.ReadLine();
            while(currWord != null)
            {
                words.Add(currWord);
                currWord = sr.ReadLine();
            }
            sr.Close();

            WordLibrary lib = new WordLibrary(words);
            Random r = new Random();
            int maxWords = lib.WordCount;
            string randomWord = lib[r.Next(0, maxWords)];
            char[] hidden = new char[randomWord.Length];
            for(int i = 0; i < randomWord.Length; i++)
            {
                hidden[i] = '_';
            }

            Console.WriteLine("Try to guess the word: ");
            Console.WriteLine(updatedWord(hidden));
            //Console.WriteLine(randomWord); //To check

            int mistakes = 0;
            bool gameLost = false;
            bool gameWon = false;

            while(!gameLost && !gameWon)
            {
                Console.Write("Enter a letter: ");
                char c = Convert.ToChar(Console.ReadLine());
                bool guessed = false;
                for(int i = 0; i < randomWord.Length; i++)
                {
                    if(c == randomWord[i] || char.ToUpper(c) == randomWord[i])
                    {
                        hidden[i] = c;
                        guessed = true;
                    }
                }
                if (guessed)
                {
                    Console.WriteLine($"Nice job, This is how the word looks like now: {updatedWord(hidden)}");
                }
                else
                {
                    mistakes += 1;
                    Console.WriteLine($"Wrong, you lost a {(BodyPartsEnum)mistakes}.");
                }

                if(mistakes == 6)
                {
                    gameLost = true;
                    Console.WriteLine("Game over, you looser.");
                }
                if (foundWord(hidden))
                {
                    gameWon = true;
                    Console.WriteLine("You Won, Nice !");
                }
            }
        }

        public static bool foundWord(char[] arr)
        {
            bool res = true;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '_')
                {
                    res = false;
                }
            }
            return res;
        }

        //ამის გარეშე დეშებს შორის დაშორებები არ ჩანდა 
        public static string updatedWord(char[] arr)
        {
            string res = "";
            for(int i = 0; i < arr.Length; i++)
            {
                res += arr[i] + " ";
            }
            return res;
        }
    }
}

