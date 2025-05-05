using System;
using System.Collections.Generic;

namespace Copmilers
{
    public static class TokenDisplayer
    {
        public static void DisplayTokens(List<Token> tokens)
        {
            Console.WriteLine("\nTokens:");
            foreach (var token in tokens)
            {
                SetColor(token.Type);
                Console.WriteLine(token);
            }
            Console.ResetColor();
        }

        public static void DisplaySummary(List<Token> tokens)
        {
            Console.WriteLine("\nToken Summary:");
            var summary = Scanner.GetTokenSummary(tokens);
            foreach (var entry in summary)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }

        public static void DisplayErrors(List<Token> tokens)
        {
            var errors = tokens.FindAll(t => t.Type == TokenType.Error); // ✅ Only Arabic is treated as error

            if (errors.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLexical Errors Detected:");
                foreach (var error in errors)
                {
                    Console.WriteLine($"[Line {error.Line}, Columns {error.StartColumn}-{error.EndColumn}] Error: '{error.Value}'");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nNo lexical errors found.");
                Console.ResetColor();
            }
        }



        static void SetColor(TokenType type)
        {
            switch (type)
            {
                case TokenType.ID:
                    Console.ForegroundColor = ConsoleColor.Cyan; break;
                case TokenType.ReservedWord:
                    Console.ForegroundColor = ConsoleColor.Magenta; break;
                case TokenType.Number:
                case TokenType.StringLiteral:
                case TokenType.Error:
                case TokenType.Unknown:
                case TokenType.UnterminatedString:
                case TokenType.UnterminatedChar:
                    Console.ForegroundColor = ConsoleColor.Red; break;
                default:
                    Console.ForegroundColor = ConsoleColor.White; break;
            }
        }

    }
}
