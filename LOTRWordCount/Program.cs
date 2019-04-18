using System;

namespace LOTRWordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            StartApp();
            OutputResult();
            ExitApp();
        }

        private static void OutputResult()
        {
            Console.WriteLine("output"); //TODO            
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
