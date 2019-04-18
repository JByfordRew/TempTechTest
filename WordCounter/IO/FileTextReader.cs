using System;
using System.IO;

namespace WordCounter.IO
{
    public class FileTextReader : ITextReader
    {
        public string SourceText(string source)
        {
            var filepath = source;
            var text = File.ReadAllText(filepath);
            return text;
        }
    }
}
