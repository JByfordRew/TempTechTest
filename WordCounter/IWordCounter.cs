using System.Collections.Generic;

namespace WordCounter
{
    public interface IWordCounter
    {
        IList<KeyValuePair<string, int>> CountWords(string source);
    }
}