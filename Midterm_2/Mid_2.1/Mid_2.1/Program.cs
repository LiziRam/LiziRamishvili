using System;
using System.IO;

namespace Mid_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/Users/liziramishvili/Desktop/LiziRamishvili/Midterm_2/Mid_2.1/Mid_2.1/Tests.txt";

            Console.WriteLine("1. Start test \n2. Add test");
            Console.Write("Choose 1 or 2: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            //If we choose to start the test
            if(choice == 1)
            {
                StreamReader sr;
                try
                {
                    sr = new StreamReader(path);
                }
                catch (Exception)
                {
                    throw;
                }
                
                int correct = 0;
                int guessed = 0;
                int questions = 0;

                string currLine = sr.ReadLine();
                if(currLine == null)
                {
                    Console.WriteLine("There are no questions entered yet.");
                }
                else
                {
                    while (currLine != null)
                    {
                        questions += 1;
                        string[] splitLine = currLine.Split("|");
                        Console.WriteLine();
                        Console.WriteLine($"Question: {splitLine[0]}");
                        for (int i = 1; i <= 4; i++)
                        {
                            string alternative = splitLine[i];
                            if (alternative[alternative.Length - 1] != '*')
                            {
                                Console.WriteLine($"\t{i}. {alternative}");
                            }
                            else
                            {
                                Console.WriteLine($"\t{i}. {alternative.Substring(0, alternative.Length - 1)}");
                                correct = i;
                            }
                        }
                        Console.Write("Enter 1, 2, 3 or 4 for an answer: ");
                        int answer = Convert.ToInt32(Console.ReadLine());
                        if (answer == correct)
                        {
                            guessed += 1;
                        }
                        currLine = sr.ReadLine();
                    }
                    Console.WriteLine($"Answered correctly: {guessed} / {questions}");
                }
                sr.Close();
            }

            //If we choose to add to the test
            else if(choice == 2)
            {
                StreamWriter sw;
                try
                {
                    sw = new StreamWriter(path, true);
                }
                catch (Exception)
                {
                    throw;
                }
                Console.WriteLine("First, write a question: ");
                string question = Console.ReadLine();
                while(question != "")
                {
                    string[] linesWithInfo = new string[5];
                    linesWithInfo[0] = question;
                    Console.WriteLine("Now enter 4 possible answers. Mark correct one with \'*\'");
                    Console.WriteLine("(It should be the last charachter of the correct answer's string)");
                    bool rightAnswerEntered = false;
                    for (int i = 1; i <= 4; i++)
                    {
                        Console.WriteLine($"Answer {i}: ");
                        linesWithInfo[i] = Console.ReadLine();
                        int currLength = linesWithInfo[i].Length;
                        if (linesWithInfo[i][currLength - 1] == '*')
                        {
                            rightAnswerEntered = true;
                        }
                    }
                    if (!rightAnswerEntered)
                    {
                        throw new rightAnswerNotEnteredException();
                    }
                    sw.WriteLine(questionAndAnswers(linesWithInfo));
                    Console.WriteLine("Write next question. If you want to finish the program, press ENTER: ");
                    question = Console.ReadLine();
                }
                sw.Close();
            }
        }

        public static string questionAndAnswers(string[] info)
        {
            string res = "";
            for(int i = 0; i < info.Length; i++)
            {
                res += info[i] + "|";
            }
            return res;
        }
    }
}

