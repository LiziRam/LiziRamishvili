using System;
using System.IO;
namespace Practice_23
{
    public class QuizEdit
    {
        private StreamWriter _sw;
        private bool _rightAnswerEntered = false;
        private string[] _info;

        public QuizEdit(string path)
		{
            try
            {
                _sw = new StreamWriter(path, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string[] Information
        {
            set
            {
                _info = value;
            }
        }

        public void ReadQuestions()
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"Answer {i}: ");
                _info[i] = Console.ReadLine();
                int currLength = _info[i].Length;
                if (_info[i][currLength - 1] == '*')
                {
                    _rightAnswerEntered = true;
                }
            }
            if (!_rightAnswerEntered)
            {
                throw new rightAnswerNotEnteredException();
            }
            _rightAnswerEntered = false;
        }

		public void addQuestion()
		{
            _sw.WriteLine(questionAndAnswers(_info));
        }

        public void Write(commandsEnum e)
        {
            string toWrite = "";
            switch ((int)e)
            {
                case 1:
                    toWrite = "First, write a question: ";
                    break;
                case 2:
                    toWrite = "Now enter 4 possible answers. Mark correct one with \'*\'";
                    break;
                case 3:
                    toWrite = "(It should be the last charachter of the correct answer's string)";
                    break;
                case 4:
                    toWrite = "Write next question. If you want to finish the program, press ENTER: ";
                    break;
            }
            Console.WriteLine(toWrite);
        }

        public void closeWriter()
        {
            _sw.Close();
        }

        public static string questionAndAnswers(string[] info)
        {
            string res = "";
            for (int i = 0; i < info.Length; i++)
            {
                res += info[i] + "|";
            }
            return res;
        }
    }
}

