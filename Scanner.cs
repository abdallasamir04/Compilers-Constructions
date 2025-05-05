using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ScannerParserProject
{
    public class Scanner
    {
        private Dictionary<string, TokenType> keywords;
        private Dictionary<string, TokenType> operators;
        private Dictionary<string, TokenType> punctuation;

        public Scanner()
        {
            InitializeKeywords();
            InitializeOperators();
            InitializePunctuation();
        }

        private void InitializeKeywords()
        {
            keywords = new Dictionary<string, TokenType>
            {
                { "void", TokenType.VOID },
                { "real", TokenType.REAL },
                { "int", TokenType.INT },
                { "return", TokenType.RETURN },
                { "if", TokenType.IF },
                { "else", TokenType.ELSE },
                { "while", TokenType.WHILE }
            };
        }

        private void InitializeOperators()
        {
            operators = new Dictionary<string, TokenType>
            {
                { "+", TokenType.PLUS },
                { "-", TokenType.MINUS },
                { "*", TokenType.TIMES },
                { "/", TokenType.DIVIDE },
                { "==", TokenType.EQUAL },
                { "!=", TokenType.NOT_EQUAL },
                { "<", TokenType.LESS_THAN },
                { ">", TokenType.GREATER_THAN },
                { "<=", TokenType.LESS_EQUAL },
                { ">=", TokenType.GREATER_EQUAL },
                { "=", TokenType.ASSIGN }
            };
        }

        private void InitializePunctuation()
        {
            punctuation = new Dictionary<string, TokenType>
            {
                { ";", TokenType.SEMICOLON },
                { ",", TokenType.COMMA },
                { "(", TokenType.LEFT_PAREN },
                { ")", TokenType.RIGHT_PAREN },
                { "[", TokenType.LEFT_BRACKET },
                { "]", TokenType.RIGHT_BRACKET },
                { "{", TokenType.LEFT_BRACE },
                { "}", TokenType.RIGHT_BRACE }
            };
        }

        public List<Token> Scan(string input)
        {
            List<Token> tokens = new List<Token>();
            int position = 0;

            while (position < input.Length)
            {
                char currentChar = input[position];

                // Skip whitespace
                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                    continue;
                }

                // Check for numbers (NUM)
                if (char.IsDigit(currentChar) || (currentChar == '-' && position + 1 < input.Length && char.IsDigit(input[position + 1])))
                {
                    string number = ScanNumber(input, ref position);
                    tokens.Add(new Token(TokenType.NUM, number, position - number.Length));
                    continue;
                }

                // Check for identifiers and keywords
                if (char.IsLetter(currentChar))
                {
                    string identifier = ScanIdentifier(input, ref position);
                    if (keywords.ContainsKey(identifier))
                    {
                        tokens.Add(new Token(keywords[identifier], identifier, position - identifier.Length));
                    }
                    else
                    {
                        tokens.Add(new Token(TokenType.ID, identifier, position - identifier.Length));
                    }
                    continue;
                }

                // Check for operators (two-character operators first)
                if (position + 1 < input.Length)
                {
                    string twoCharOp = input.Substring(position, 2);
                    if (operators.ContainsKey(twoCharOp))
                    {
                        tokens.Add(new Token(operators[twoCharOp], twoCharOp, position));
                        position += 2;
                        continue;
                    }
                }

                // Check for single-character operators and punctuation
                string oneCharOp = currentChar.ToString();
                if (operators.ContainsKey(oneCharOp))
                {
                    tokens.Add(new Token(operators[oneCharOp], oneCharOp, position));
                    position++;
                    continue;
                }
                else if (punctuation.ContainsKey(oneCharOp))
                {
                    tokens.Add(new Token(punctuation[oneCharOp], oneCharOp, position));
                    position++;
                    continue;
                }

                // If we get here, we have an unrecognized character
                tokens.Add(new Token(TokenType.ERROR, oneCharOp, position));
                position++;
            }

            // Add EOF token
            tokens.Add(new Token(TokenType.EOF, "EOF", position));
            return tokens;
        }

        private string ScanNumber(string input, ref int position)
        {
            int start = position;
            bool hasDecimal = false;

            // Check for negative sign
            if (input[position] == '-')
            {
                position++;
            }

            // Scan digits before decimal point
            while (position < input.Length && char.IsDigit(input[position]))
            {
                position++;
            }

            // Check for decimal point
            if (position < input.Length && input[position] == '.')
            {
                hasDecimal = true;
                position++;

                // Scan digits after decimal point
                while (position < input.Length && char.IsDigit(input[position]))
                {
                    position++;
                }
            }

            return input.Substring(start, position - start);
        }

        private string ScanIdentifier(string input, ref int position)
        {
            int start = position;

            // First character is already checked to be a letter
            position++;

            // Scan subsequent letters and digits
            while (position < input.Length && (char.IsLetterOrDigit(input[position])))
            {
                position++;
            }

            return input.Substring(start, position - start);
        }
    }
}