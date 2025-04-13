using System;
using System.Collections.Generic;
using System.IO;

namespace Copmilers
{
    public static class Scanner
    {
        public static List<Token> Scan(string[] lines)
        {
            var tokens = new List<Token>();

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                string line = lines[lineIndex];
                int i = 0;

                while (i < line.Length)
                {
                    char current = line[i];

                    // Skip whitespace
                    if (char.IsWhiteSpace(current)) { i++; continue; }

                    int start = i;

                    // ASCII Identifiers
                    if (IsAsciiLetter(current))
                    {
                        while (i < line.Length && (char.IsLetterOrDigit(line[i]) || line[i] == '_')) i++;
                        string word = line[start..i];
                        TokenType tokenType = ReservedWordsManager.GetTokenType(word);
                        tokens.Add(new Token(tokenType, word, lineIndex + 1, start + 1));
                        continue;
                    }

                    // Arabic 
                    else if (char.IsLetter(current))
                    {
                        int j = i;
                        while (j < line.Length && char.IsLetter(line[j]) && !IsAsciiLetter(line[j]))
                            j++;

                        string word = line[i..j];
                        tokens.Add(new Token(TokenType.Error, word, lineIndex + 1, i + 1));
                        i = j;
                        continue;
                    }

                    //  Numbers
                    if (char.IsDigit(current) || (current == '-' && i + 1 < line.Length && char.IsDigit(line[i + 1])))
                    {
                        bool hasDecimal = false;
                        i += (current == '-') ? 1 : 0;
                        while (i < line.Length && (char.IsDigit(line[i]) || (line[i] == '.' && !hasDecimal)))
                        {
                            if (line[i] == '.') hasDecimal = true;
                            i++;
                        }
                        string number = line[start..i];
                        tokens.Add(new Token(TokenType.Number, number, lineIndex + 1, start + 1));
                        continue;
                    }

                    // String Literals
                    if (current == '\"')
                    {
                        i++;
                        while (i < line.Length && line[i] != '\"') i++;
                        if (i < line.Length && line[i] == '\"')
                        {
                            i++;
                            tokens.Add(new Token(TokenType.StringLiteral, line[start..i], lineIndex + 1, start + 1));
                        }
                        else
                        {
                            tokens.Add(new Token(TokenType.UnterminatedString, line[start..], lineIndex + 1, start + 1));
                            i = line.Length; // ✅ Skip rest of the line
                        }
                        continue;
                    }

                    // 🔠 Char Literals
                    if (current == '\'')
                    {
                        i++;
                        if (i + 1 < line.Length && line[i + 1] == '\'')
                        {
                            i += 2;
                            tokens.Add(new Token(TokenType.CharLiteral, line[start..(i + 1)], lineIndex + 1, start + 1));
                        }
                        else
                        {
                            tokens.Add(new Token(TokenType.UnterminatedChar, line[start..], lineIndex + 1, start + 1));
                            i = line.Length; // ✅ Skip rest of the line
                        }
                        continue;
                    }

                    // 💬 Comments
                    if (current == '{')
                    {
                        i++;
                        while (i < line.Length && line[i] != '}') i++;
                        if (i < line.Length && line[i] == '}')
                        {
                            i++;
                            tokens.Add(new Token(TokenType.Comment, line[start..i], lineIndex + 1, start + 1));
                        }
                        else
                        {
                            tokens.Add(new Token(TokenType.UnclosedComment, line[start..], lineIndex + 1, start + 1));
                            i = line.Length; // ✅ Skip rest of the line
                        }
                        continue;
                    }

                    // ➕ Two-character operators
                    string twoChar = (i + 1 < line.Length) ? line.Substring(i, 2) : string.Empty;

                    if (twoChar == ":=") { tokens.Add(new Token(TokenType.Assign, ":=", lineIndex + 1, start + 1)); i += 2; continue; }
                    if (twoChar == "==") { tokens.Add(new Token(TokenType.Equal, "==", lineIndex + 1, start + 1)); i += 2; continue; }
                    if (twoChar == "!=") { tokens.Add(new Token(TokenType.NotEqual, "!=", lineIndex + 1, start + 1)); i += 2; continue; }
                    if (twoChar == "<=") { tokens.Add(new Token(TokenType.LessEqual, "<=", lineIndex + 1, start + 1)); i += 2; continue; }
                    if (twoChar == ">=") { tokens.Add(new Token(TokenType.GreaterEqual, ">=", lineIndex + 1, start + 1)); i += 2; continue; }
                    if (twoChar == "++") { tokens.Add(new Token(TokenType.Increment, "++", lineIndex + 1, start + 1)); i += 2; continue; }
                    if (twoChar == "--") { tokens.Add(new Token(TokenType.Decrement, "--", lineIndex + 1, start + 1)); i += 2; continue; }
                    if (twoChar == "&&") { tokens.Add(new Token(TokenType.LogicalAnd, "&&", lineIndex + 1, start + 1)); i += 2; continue; }
                    if (twoChar == "||") { tokens.Add(new Token(TokenType.LogicalOr, "||", lineIndex + 1, start + 1)); i += 2; continue; }

                    // ➖ Single-character symbols
                    TokenType type = current switch
                    {
                        '+' => TokenType.Plus,
                        '-' => TokenType.Minus,
                        '*' => TokenType.Multiply,
                        '/' => TokenType.Divide,
                        '%' => TokenType.Modulus,
                        '=' => TokenType.Equal,
                        '<' => TokenType.LessThan,
                        '>' => TokenType.GreaterThan,
                        ';' => TokenType.Semicolon,
                        ',' => TokenType.Comma,
                        '.' => TokenType.Dot,
                        ':' => TokenType.Colon,
                        '?' => TokenType.QuestionMark,
                        '!' => TokenType.LogicalNot,
                        '&' => TokenType.BitwiseAnd,
                        '|' => TokenType.BitwiseOr,
                        '^' => TokenType.BitwiseXor,
                        '(' => TokenType.LeftParen,
                        ')' => TokenType.RightParen,
                        '{' => TokenType.LeftBrace,
                        '}' => TokenType.RightBrace,
                        '[' => TokenType.LeftBracket,
                        ']' => TokenType.RightBracket,
                        _ => TokenType.Unknown
                    };

                    tokens.Add(new Token(type, current.ToString(), lineIndex + 1, start + 1));
                    i++;
                }
            }

            return tokens;
        }

        public static Dictionary<TokenType, int> GetTokenSummary(List<Token> tokens)
        {
            Dictionary<TokenType, int> summary = new();
            foreach (var token in tokens)
            {
                if (!summary.ContainsKey(token.Type))
                    summary[token.Type] = 0;
                summary[token.Type]++;
            }
            return summary;
        }

        public static string[] ReadSourceFile(string path)
        {
            return File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();
        }

        private static bool IsAsciiLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }
    }
}
