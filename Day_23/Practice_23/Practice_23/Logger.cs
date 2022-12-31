using System;
using System.IO;
namespace Practice_23
{
	public static class Logger
	{
		private static string _path = "/Users/liziramishvili/Desktop/LiziRamishvili/Day_23/Practice_23/Practice_23/Logs.txt";
        private static StreamWriter _sw;

		public static void Log(string s)
		{
            try
            {
                _sw = new StreamWriter(_path, true);
            }
            catch (Exception)
            {
                throw;
            }
            _sw.WriteLine(s);

            _sw.Close(); 
        }
	}
}

