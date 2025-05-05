namespace Copmilers
{
    public enum TokenType
    {
        // Literals
        ID,
        Number,
        StringLiteral,
    

        // Keywords 
        ReservedWord,
        If, Else, While, Int, Real, Return, Void,  

        // Operators
        Plus, Minus, Multiply, Divide,
        Assign,
        Equal,
        NotEqual,
        LessThan,
        GreaterThan,
        LessEqual,
        GreaterEqual,

        // Symbols / Punctuation
        Semicolon,
        Comma,
        

        // Grouping
        LeftParen, RightParen,
        LeftBrace, RightBrace,
        LeftBracket, RightBracket,


        // Errors
        Error,
        Unknown,
        UnterminatedString,
        UnterminatedChar
    }
}
