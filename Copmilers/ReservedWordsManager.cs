using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copmilers
{

    public class ReservedWordsManager
    {
        private static HashSet<string> reservedWords = new HashSet<string>
    {
        "if", "then", "else", "while", "for", "int", "void", "return", "break", "continue", "class",
        "public", "private", "protected", "static", "new", "try", "catch", "finally",
        "throw", "this", "null", "true", "false", "switch", "case", "default", "do", "const", "sizeof",
        "enum", "long", "double", "float", "char", "string", "namespace", "using", "extern", "delegate",
        "yield", "typeof", "is", "as", "await", "async", "lock", "interface", "override",
        "base", "goto", "checked", "unchecked", "unsafe", "readonly", "main", "volatile", "dynamic"
    };

        public static bool IsReservedWord(string identifier)
        {
            return reservedWords.Contains(identifier);
        }
    }



}
