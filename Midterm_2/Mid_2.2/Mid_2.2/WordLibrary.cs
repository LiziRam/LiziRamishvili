using System;
using System.Collections.Generic;
using System.IO;

namespace Mid_2._2
{
	public class WordLibrary
	{
		private List<string> _library;
		private int _wordCount;

		public WordLibrary(List<string> words)
		{
			_library = words;
			_wordCount = words.Count;
		}

		public string this[int index]
		{
			get
			{
				if(index > _wordCount - 1)
				{
					throw new IndexOutOfRangeException(); 
				}
				return _library[index];
			}
		}

		public int WordCount
		{
			get
			{
				return _wordCount;
			}
		}

	}
}

