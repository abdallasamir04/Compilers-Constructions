using System;
using System.Collections.Generic;

namespace Copmilers
{
    public static class ScannerController
    {
        public static void Run()
        {
            UserInterface.ShowMessage("----- Scanner -----\n  File or Manual Input ");
            string[] lines = GetSourceLines();

            if (lines.Length == 0)
            {
                UserInterface.ShowMessage("No code to scan.");
                return;
            }

            List<Token> tokens = Scanner.Scan(lines);

            TokenDisplayer.DisplayTokens(tokens);
            TokenDisplayer.DisplaySummary(tokens);
            TokenDisplayer.DisplayErrors(tokens);

            if (UserInterface.GetUserInput("Do you want to save the token list to a file? (y/n): ").ToLower() == "y")
            {
                ResultSaver.Save(tokens);
            }

            UserInterface.ShowMessage("Scanning complete. Thanks for using the scanner!");


        }

        private static string[] GetSourceLines()
        {
            string mode = UserInterface.GetUserInput("Scan a file or type code? (file/manual): ").ToLower();

            if (mode == "file")
            {
                string filePath = UserInterface.GetUserInput("Enter the file path: ");
                return Scanner.ReadSourceFile(filePath);
            }
            else
            {
                Console.WriteLine("Enter your code (finish with an empty line):");
                var lines = new List<string>();
                string? line;
                while ((line = Console.ReadLine()) != null && !string.IsNullOrWhiteSpace(line))
                {
                    lines.Add(line);
                }
                return lines.ToArray();
            }
        }

    }
}
