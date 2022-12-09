using System;
using System.IO;

namespace Practice_23
{
    class Program
    {
        public static void PublisherProcessCompletedWrong(object sender, EventArgs a)
        {
            Console.WriteLine("Answer seems wrong.");
            
        }

        public static void PublisherProcessCompletedCorrect(object sender, EventArgs a)
        {
            Console.WriteLine("Answer seems correct");
            
        }

        static void Main(string[] args)
        {
            string path = @"/Users/liziramishvili/Desktop/LiziRamishvili/Day_23/Practice_23/Practice_23/Tests.txt";

            Console.WriteLine("1. Start test \n2. Add test");
            Console.Write("Choose 1 or 2: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            //If we choose to start the test
            if (choice == 1)
            {
                QuizTake quiz = new QuizTake(path);

                

                string currLine = quiz.CurrentLine();
                if (currLine == null)
                {
                    Console.WriteLine("There are no questions entered yet.");
                }
                else
                {
                    while (currLine != null)
                    {
                        quiz.Questions = 1;
                        quiz.Start();
                        quiz.Answer();

                        Publisher pub = new Publisher(); 
                        int answer = quiz.AnswerChoice; 
                        int correct = quiz.CorrectChoice; 
                        string[] choices = quiz.Choices; 
                        if(answer == correct) 
                        {
                            pub.ProcessCompleted += PublisherProcessCompletedCorrect; 
                            Logger.Log($"Your correct Answer: {choices[correct].Substring(0, choices[correct].Length - 1)}");
                        }
                        else
                        {
                            pub.ProcessCompleted += PublisherProcessCompletedWrong; 
                            Logger.Log($"Your wrong Answer: {choices[answer]}, Actual Correct Answer: {choices[correct].Substring(0, choices[correct].Length - 1)}");
                        }
                        pub.StartProcess(); 
                        currLine = quiz.CurrentLine();
                    }
                    quiz.Stats();
                }
                quiz.closeReader();
            }

            //If we choose to add to the test
            else if (choice == 2)
            {
                QuizEdit quizQuestions = new QuizEdit(path);
                quizQuestions.Write(commandsEnum.writeQuestion);

                string question = Console.ReadLine();
                while (question != "")
                {
                    string[] linesWithInfo = new string[5];
                    linesWithInfo[0] = question;
                    quizQuestions.Information = linesWithInfo;

                    quizQuestions.Write(commandsEnum.enterAnswers);
                    quizQuestions.Write(commandsEnum.additionalInfo);
                    quizQuestions.ReadQuestions();
                    quizQuestions.addQuestion();

                    quizQuestions.Write(commandsEnum.continueOrStop);
                    question = Console.ReadLine();
                }
                quizQuestions.closeWriter();
            }
        }
    }
}

