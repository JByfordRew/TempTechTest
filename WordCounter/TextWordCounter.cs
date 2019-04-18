using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCounter
{
    public class TextWordCounter : IWordCounter
    {
        public IDictionary<string,int> wordCount = new Dictionary<string, int>();
        public Action<IDictionary<string, int>, string> addOrUpdate = AddOrUpdateWordCount;

        public IList<KeyValuePair<string,int>> CountWords(string source)
        {
            var text = Preprocess(source);            
            var words = Words(text);
            var wordCount = CountWords(words);
            var wordList = WordList(wordCount);
            return wordList;
        }

        private string Preprocess(string text)
        {
            text = text ?? "";
            text = StandardiseWhitespace(text);
            return text;
        }

        private List<KeyValuePair<string, int>> WordList(IDictionary<string, int> items)
        {
            return items.Select(x => new KeyValuePair<string, int>(x.Key, x.Value)).ToList();
        }

        private IDictionary<string, int> CountWords(List<string> words)
        {            
            words.ForEach(word => RecordIfWord(word, wordCount));
            return wordCount;
        }

        private void RecordIfWord(string word, IDictionary<string, int> wordCount)
        {
            word = word.ToLower();
            if (word.All(Char.IsLetter))
            {
                addOrUpdate(wordCount, word);
                //AddOrUpdateWordCount(wordCount, word);
            }            
        }

        private static void AddOrUpdateWordCount(IDictionary<string, int> wordCount, string key)
        {            
            if (!wordCount.ContainsKey(key))
            {
                wordCount.Add(key, 1);
            }
            else
            {
                wordCount[key]++;
            }
        }

        private List<string> Words(string text)
        {
            return text.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }
        
        public string StandardiseWhitespace(string text)
        {
            return string.Join(" ", text.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
