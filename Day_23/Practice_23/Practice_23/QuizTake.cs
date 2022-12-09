using System;
using System.IO;

namespace Practice_23
{
	public class QuizTake
	{
        private StreamReader _sr;
        private int _correct;
        private int _guessed;
        private int _questions;
        private string _currLine;
        private string[] _splitCurrLine;
        private int _answer;

        public QuizTake(string path)
        {
            try
            {
                _sr = new StreamReader(path);
            }
            catch (Exception)
            {
                throw;
            }

            _correct = 0;
            _guessed = 0;
            _questions = 0;
            _currLine = "";
        }

        public void Start()
        {
            _splitCurrLine = _currLine.Split("|");
            Console.WriteLine();
            Console.WriteLine($"Question: {_splitCurrLine[0]}");
            for (int i = 1; i <= 4; i++)
            {
                string alternative = _splitCurrLine[i];
                if (alternative[alternative.Length - 1] != '*')
                {
                    Console.WriteLine($"\t{i}. {alternative}");
                }
                else
                {
                    Console.WriteLine($"\t{i}. {alternative.Substring(0, alternative.Length - 1)}");
                    _correct = i;
                }
            }
        }

        public int CorrectChoice { get { return _correct; } }
        public int AnswerChoice { get { return _answer; } }
        public string[] Choices { get { return _splitCurrLine; } }

        public void Answer()
        {
            Console.Write("Enter 1, 2, 3 or 4 for an answer: ");
            _answer = Convert.ToInt32(Console.ReadLine());
            if (_answer == _correct)
            {
                _guessed += 1;
            }
        }

        public void Stats()
        {
            Console.WriteLine($"Answered correctly: {_guessed} / {_questions}");
        }

        public int Questions
        {
            set
            {
                _questions += value;
            }
        }

        public string CurrentLine()
        {
            _currLine = _sr.ReadLine();
            return _currLine;
        }

        public void closeReader()
        {
            _sr.Close();
        }
    }
}

