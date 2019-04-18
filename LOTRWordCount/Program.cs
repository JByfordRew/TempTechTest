using System;
using System.Collections.Generic;
using WordCounter;
using System.Linq;

namespace LOTRWordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            StartApp();
            var top10 = new FileWordCounter().CountTopWords("example-lotr-fotr.txt", 10).ToList();
            OutputResult(top10);
            ExitApp();
        }

        private static void OutputResult(List<KeyValuePair<string,int>> items)
        {
            var ascendingItems = items.OrderBy(x => x.Value).ToList();
            var position = items.Count;
            while (position > 0) {
                var item = ascendingItems[position - 1];
                Console.WriteLine($"{position:00}: {item.Value} - {item.Key}");
                position--;
            }                        
        }

        private static void StartApp()
        {
            Console.WriteLine("Word occurrences count in text document.");
            Console.WriteLine();
            Console.Write("Press any key to start.");
            Console.ReadKey();
            Console.WriteLine("\rProcessing ...         ");
            Console.WriteLine();
        }

        private static void ExitApp()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
