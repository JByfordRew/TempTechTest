using System.Collections.Generic;
using System.Linq;
using WordCounter.IO;

namespace WordCounter
{
    public class FileTopWordCounter : ITopWordCounter
    {
        private readonly ITextReader textReader;
        private readonly IWordCounter textWordCounter;

        public FileTopWordCounter(ITextReader textReader, IWordCounter textWordCounter)
        {
            this.textReader = textReader;
            this.textWordCounter = textWordCounter;
        }

        public IList<KeyValuePair<string,int>> CountTopWords(string source, int top)
        {
            var text = textReader.SourceText(source);
            var words = textWordCounter.CountWords(text);
            var topWords = words.OrderByDescending(x => x.Value).Take(top);
            return topWords.ToList();
        }              
    }
}
