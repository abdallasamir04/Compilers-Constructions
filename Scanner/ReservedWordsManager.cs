using System.Collections.Generic;

namespace Copmilers
{
    public static class ReservedWordsManager
    {
        private static readonly HashSet<string> reservedWords = new()
        {
            "if", "then", "else", "while", "for", "int", "void", "return", "break", "continue",
            "class", "auto", "public", "private", "protected", "static", "new", "try", "catch",
            "finally", "throw", "this", "null", "true", "false", "switch", "case", "default",
            "do", "const", "sizeof", "enum", "long", "double", "float", "char", "string",
            "namespace", "using", "extern", "delegate", "yield", "typeof", "is", "as", "await",
            "async", "lock", "interface", "override", "base", "goto", "checked", "unchecked",
            "unsafe", "readonly", "main", "volatile", "dynamic"
        };

        public static bool IsReservedWord(string identifier)
        {
            return reservedWords.Contains(identifier);
        }

        public static TokenType GetTokenType(string identifier)
        {
            return reservedWords.Contains(identifier)
                ? TokenType.ReservedWord
                : TokenType.Identifier;
        }
    }
}
