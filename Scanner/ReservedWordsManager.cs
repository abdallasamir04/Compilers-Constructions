using System.Collections.Generic;

namespace Copmilers
{
    public static class ReservedWordsManager
    {
        private static readonly HashSet<string> reservedWords = new()
        {
           "void" , "real" , "int" , "return" , "if" , "else" , "while" , "Num" , "ID"        };

        public static bool IsReservedWord(string identifier)
        {
            return reservedWords.Contains(identifier);
        }

        public static TokenType GetTokenType(string identifier)
        {
            return reservedWords.Contains(identifier)
                ? TokenType.ReservedWord
                : TokenType.ID;
        }
    }
}
