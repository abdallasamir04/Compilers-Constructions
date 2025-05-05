namespace ScannerParserProject
{
    public enum TokenType
    {
        // Keywords
        VOID, REAL, INT, RETURN, IF, ELSE, WHILE,

        // Operators
        PLUS, MINUS, TIMES, DIVIDE, EQUAL, NOT_EQUAL,
        LESS_THAN, GREATER_THAN, LESS_EQUAL, GREATER_EQUAL,
        ASSIGN,

        // Punctuation
        SEMICOLON, COMMA, LEFT_PAREN, RIGHT_PAREN,
        LEFT_BRACKET, RIGHT_BRACKET, LEFT_BRACE, RIGHT_BRACE,

        // Literals and identifiers
        NUM, ID,

        // End of file
        EOF,

        // Error
        ERROR
    }

    public class Token
    {
        public TokenType Type { get; set; }
        public string Lexeme { get; set; }
        public int Position { get; set; }

        public Token(TokenType type, string lexeme, int position)
        {
            Type = type;
            Lexeme = lexeme;
            Position = position;
        }

        public override string ToString()
        {
            return $"{Type}: {Lexeme} at position {Position}";
        }
    }
}