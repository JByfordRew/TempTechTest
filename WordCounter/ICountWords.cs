using System.Collections.Generic;

namespace WordCounter
{
    public interface ICountWords
    {
        IList<KeyValuePair<string, int>> CountTopWords(string source, int top);
    }
}