using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WordCounter
{
    public class ParallelFileLineTopWordCounter : ITopWordCounter
    {
        private readonly ConcurrentDictionary<string, int> wordCounts = new ConcurrentDictionary<string, int>();
        private readonly TextWordCounter wordCounter = new TextWordCounter();

        public ParallelFileLineTopWordCounter()
        {
            wordCounter = new TextWordCounter();
            wordCounter.wordCount = wordCounts;
            wordCounter.addOrUpdate = AddOrUpdate;
        }

        private void AddOrUpdate(IDictionary<string, int> dict, string word)
        {
            wordCounts.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1);
        }

        public IList<KeyValuePair<string, int>> CountTopWords(string source, int top)
        {
            Parallel.ForEach(File.ReadLines(source), CountWordsInLine);
            return wordCounts.OrderByDescending(x => x.Value).Take(10).Select(x => new KeyValuePair<string, int>(x.Key, x.Value)).ToList();
        }

        private void CountWordsInLine(string line, ParallelLoopState arg2, long lineNumber)
        {
            wordCounter.CountWords(line);
        }
    }
}
