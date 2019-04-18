using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCounter
{
    public class FileWordCounter : ICountWords
    {
        public IList<KeyValuePair<string,int>> CountWords(string source)
        {
            var filepath = source;
            var text = File.ReadAllText(filepath);
            text = StandardiseWhitespace(text);
            var words = text.Split(" ").ToList();

            var wordCount = new Dictionary<string, int>();
            words.ForEach(word =>
            {
                if (word.All(Char.IsLetter))
                {
                    var key = word.ToLower();
                    if (!wordCount.ContainsKey(key))
                    {
                        wordCount.Add(key, 1);
                    }
                    else
                    {
                        wordCount[key]++;
                    }
                }
            });

            var topWords = wordCount.OrderByDescending(x => x.Value)
                .Take(10)
                .Select(x => new KeyValuePair<string, int>(x.Key, x.Value))
                .ToList();

            return topWords;
        }

        public static string StandardiseWhitespace(string text)
        {
            return string.Join(" ", text.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
