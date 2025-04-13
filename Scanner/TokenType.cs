namespace Copmilers
{
    public enum TokenType
    {
        // Literals
        Identifier,
        Number,
        StringLiteral,
        CharLiteral,
        BooleanLiteral,

        // Keywords 
        ReservedWord,
        If, Then, Else, While, For, Do, Int, Float, Real, Char, String, Bool,
        True, False, Return, Break, Continue, Void, Class, Static, Public, Private, Protected,

        // Operators
        Plus, Minus, Multiply, Divide, Modulus,
        Assign,
        Equal,
        NotEqual,
        LessThan,
        GreaterThan,
        LessEqual,
        GreaterEqual,
        LogicalAnd,
        LogicalOr,
        LogicalNot,
        BitwiseAnd,
        BitwiseOr,
        BitwiseXor,
        Increment,
        Decrement,

        // Symbols / Punctuation
        Semicolon,
        Comma,
        Colon,
        Dot,
        QuestionMark,

        // Grouping
        LeftParen, RightParen,
        LeftBrace, RightBrace,
        LeftBracket, RightBracket,

        // Comments
        Comment,
        UnclosedComment,

        // Errors
        Error,
        Unknown,
        UnterminatedString,
        UnterminatedChar
    }
}
