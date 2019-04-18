using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCounter
{
    public class TextWordCounter : IWordCounter
    {                
        public IList<KeyValuePair<string,int>> CountWords(string source)
        {
            var text = Preprocess(source);            
            var words = Words(text);
            var wordCount = CountWords(words);
            var wordList = WordList(wordCount);
            return wordList;
        }

        private static string Preprocess(string text)
        {
            text = text ?? "";
            text = StandardiseWhitespace(text);
            return text;
        }

        private static List<KeyValuePair<string, int>> WordList(Dictionary<string, int> items)
        {
            return items.Select(x => new KeyValuePair<string, int>(x.Key, x.Value)).ToList();
        }

        private static Dictionary<string, int> CountWords(List<string> words)
        {
            var wordCount = new Dictionary<string, int>();
            words.ForEach(word => RecordIfWord(word, wordCount));
            return wordCount;
        }

        private static void RecordIfWord(string word, Dictionary<string, int> wordCount)
        {
            word = word.ToLower();
            if (word.All(Char.IsLetter))
            {
                AddOrUpdateWordCount(wordCount, word);
            }            
        }

        private static void AddOrUpdateWordCount(Dictionary<string, int> wordCount, string key)
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

        private static List<string> Words(string text)
        {
            return text.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }
        
        public static string StandardiseWhitespace(string text)
        {
            return string.Join(" ", text.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
