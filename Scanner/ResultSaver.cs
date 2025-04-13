using System;
using System.Collections.Generic;
using System.IO;

namespace Copmilers
{
    public static class ResultSaver
    {
        public static void Save(List<Token> tokens)
        {
            string path = "tokens_output.txt";
            var summary = Scanner.GetTokenSummary(tokens);

            using StreamWriter writer = new(path);
            foreach (var token in tokens)
                writer.WriteLine(token);

            writer.WriteLine();
            foreach (var entry in summary)
                writer.WriteLine($"{entry.Key}: {entry.Value}");

            Console.WriteLine($"Results saved to: {path}");
        }
    }
}
