using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parselets;
using System.Collections.Generic;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;

namespace PolynomialsPrattAlgorithm.Parsing
{
    public class Parser
    {
        private readonly List<Token> _tokens;
        private int _current = 0;
        private readonly Dictionary<TokenType, IPrefixParselet> _prefixParselets = new Dictionary<TokenType, IPrefixParselet>();
        private readonly Dictionary<TokenType, IInfixParselet> _infixParselet = new Dictionary<TokenType, IInfixParselet>();

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
        }

        public void Register(TokenType token, IPrefixParselet parselet)
            => _prefixParselets.Add(token, parselet);

        public void Register(TokenType token, IInfixParselet parselet)
            => _infixParselet.Add(token, parselet);

        private IPrefixParselet GetPrefixParselet(TokenType token)
        {
            if (_prefixParselets.TryGetValue(token, out var value))
                return value;

            return null;
        }

        private IInfixParselet GetInfixParselet(TokenType token)
        {
            if (_infixParselet.TryGetValue(token, out var value))
                return value;

            return null;
        }

        public IExpr ParseExpression(int precedence = 0)
        {
            var token = Advance();
            var prefix = GetPrefixParselet(token.Type);

            // TODO Fix error message
            if (prefix is null) throw new ParseError("Could not parse \"\"");

            var left = prefix.Parse(this, token);

            while (precedence < GetPrecedence())
            {
                token = Advance();

                var infix = GetInfixParselet(token.Type);
                left = infix.Parse(this, left, token);
            }

            return left;
        }


        private int GetPrecedence()
        {
            var next = Peek();
            var parser = GetInfixParselet(next.Type);
            return parser?.GetPrecedence() ?? 0;
        }

        public Token Consume(TokenType type, string message)
        {
            if (Check(type)) return Advance();

            throw Error(Peek(), message);
        }

        private bool Check(TokenType type)
        {
            if (IsAtEnd()) return false;

            return Peek().Type == type;
        }

        private Token Advance()
        {
            if (!IsAtEnd()) _current++;

            return Previous();
        }

        private bool IsAtEnd() => Peek().Type == EOF;
        private Token Peek() => _tokens[_current];
        private Token Previous() => _tokens[_current - 1];

        private ParseError Error(Token token, string message)
        {
            return new ParseError($"Error a token {token.Type}: {message}");
        }
    }
}
