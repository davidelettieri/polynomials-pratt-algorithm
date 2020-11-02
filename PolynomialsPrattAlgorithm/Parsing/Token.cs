namespace PolynomialsPrattAlgorithm.Parsing
{
    public class Token
    {
        public TokenType Type { get; }
        public int Column { get; }
        public string Lexeme { get; }
        public object Value { get; }

        public Token(TokenType type, int column, string lexeme, object value)
        {
            Type = type;
            Column = column;
            Lexeme = lexeme;
            Value = value;
        }

        public override string ToString()
        {
            return $"{{{nameof(Type)}={Type}, {nameof(Column)}={Column}, {nameof(Lexeme)}={Lexeme}, {nameof(Value)}={Value}}}";
        }
    }
}
