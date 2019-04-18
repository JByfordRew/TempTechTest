using System.Collections.Generic;

namespace WordCounter
{
    public interface ITopWordCounter
    {
        IList<KeyValuePair<string, int>> CountTopWords(string source, int top);
    }
}