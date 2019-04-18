using System;
using System.Collections.Generic;

namespace WordCounter
{
    public class FileWordCounter : ICountWords
    {
        public IList<KeyValuePair<string,int>> CountWords(string source)
        {
            return new List<KeyValuePair<string, int>>();
        }
    }
}
