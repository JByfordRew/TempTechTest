using System;
using System.Collections.Generic;

namespace WordCounter
{
    public class FileWordCounter : ICountWords
    {
        public IList<KeyValuePair<string,int>> CountWords(string source)
        {
            return new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string,int>( "a", 1),
                new KeyValuePair<string,int>( "b", 2),
                new KeyValuePair<string,int>( "c", 3),
                new KeyValuePair<string,int>( "d", 4),
                new KeyValuePair<string,int>( "e", 5),
                new KeyValuePair<string,int>( "f", 6),
                new KeyValuePair<string,int>( "g", 7),
                new KeyValuePair<string,int>( "h", 8),
                new KeyValuePair<string,int>( "i", 9),
                new KeyValuePair<string,int>( "j", 10),
            };
        }
    }
}
