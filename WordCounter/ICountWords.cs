using System.Collections.Generic;

namespace WordCounter
{
    public interface ICountWords
    {
        IList<KeyValuePair<string, int>> CountWords(string source);
    }
}