using Copmilers;

public class Token
{
    public TokenType Type { get; }
    public string Value { get; }
    public int Line { get; }
    public int StartColumn { get; }
    public int EndColumn => StartColumn + Value.Length - 1;

    public Token(TokenType type, string value, int line, int startColumn)
    {
        Type = type;
        Value = value;
        Line = line;
        StartColumn = startColumn;
    }

    public override string ToString()
    {
        return $"[{Line}:{StartColumn}-{EndColumn}] {Type}: '{Value}'";
    }
}
