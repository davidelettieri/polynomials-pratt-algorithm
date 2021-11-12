using PolynomialsPrattAlgorithm.Denotations;
using PolynomialsPrattAlgorithm.Expressions;
using System.Collections.Generic;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;

namespace PolynomialsPrattAlgorithm.Parsing
{
    public class Parser
    {
        private readonly List<Token> _tokens;
        private int _current = 0;
        private readonly Dictionary<TokenType, IPrefixDenotation> _prefixDenotations = new Dictionary<TokenType, IPrefixDenotation>();
        private readonly Dictionary<TokenType, IInfixDenotation> _infixDenotation = new Dictionary<TokenType, IInfixDenotation>();

        public Parser(List<Token> tokens)
        {
            _prefixDenotations.Add(NUMBER, new NumberDenotation());
            _prefixDenotations.Add(VAR, new VarDenotation());
            _prefixDenotations.Add(LEFT_PAREN, new GroupDenotation());
            _prefixDenotations.Add(MINUS, new NegateDenotation());
            _infixDenotation.Add(VAR, new ImplicitProductDenotation(Precedence.PRODUCT, Precedence.PRODUCT));
            _infixDenotation.Add(NUMBER, new ImplicitProductDenotation(Precedence.PRODUCT, Precedence.PRODUCT));
            _infixDenotation.Add(PLUS, new BinaryOperatorDenotation(Precedence.SUM, Precedence.SUM));
            _infixDenotation.Add(MINUS, new BinaryOperatorDenotation(Precedence.SUM, Precedence.SUM));
            _infixDenotation.Add(STAR, new BinaryOperatorDenotation(Precedence.PRODUCT, Precedence.PRODUCT));
            _infixDenotation.Add(SLASH, new BinaryOperatorDenotation(Precedence.PRODUCT, Precedence.PRODUCT));
            _infixDenotation.Add(POWER, new BinaryOperatorDenotation(Precedence.EXPONENT + 1, Precedence.EXPONENT));

            _tokens = tokens;
        }

        private IPrefixDenotation GetPrefixDenotation(TokenType token)
        {
            if (_prefixDenotations.TryGetValue(token, out var value))
                return value;

            return null;
        }

        private IInfixDenotation GetInfixDenotation(TokenType token)
        {
            if (_infixDenotation.TryGetValue(token, out var value))
                return value;

            return null;
        }

        public PolynomialEvaluation ParsePolynomialEvaluation()
        {
            var expr = ParseExpression();
            var result = new PolynomialEvaluation(expr);

            while (!IsAtEnd())
            {
                Consume(COMMA, "Expect ','.");
                var assignStmt = Assign();
                result.AddVariableValue(assignStmt.Key, assignStmt.Value);
            }

            return result;
        }

        private KeyValuePair<char, double> Assign()
        {
            var name = ParseExpression() as VariableExpr;

            if (name is null)
                throw new ParseError("Expect variable name.");

            Consume(EQUAL, "Expect '=' after variable name.");
            var value = ParseExpression() as ConstExpr;

            if (value is null)
                throw new ParseError("Expect numeric value.");

            return new KeyValuePair<char, double>(name.Name, value.Value);
        }

        public IExpr ParseExpression(int precedence = 0)
        {
            // STEP 1: Parse looks at the first symbol and assumes it is an operator
            // with no argument on its left side
            var token = Advance();
            var prefix = GetPrefixDenotation(token.Type);

            if (prefix is null) throw new ParseError($"Could not parse \"{token.Lexeme}\" at column {token.Column}");

            // STEP 2: Parse execute the denotation associated with this symbol
            var left = prefix.Parse(this, token);
            // After running the current denotation we parsed the expression and we are
            // a the next symbol

            // STEP 3: here is were we decide if the current expression is an argument of the
            // next operator or if we should return it
            while (precedence < PeekPrecedence())
            {
                // STEP 4: if the prefix expression is an argument of the following symbol
                // we pass it to the infix denotation
                token = Advance();

                var infix = GetInfixDenotation(token.Type);
                if (infix is null) throw new ParseError($"Could not parse \"{token.Lexeme}\" at column {token.Column}");
                
                left = infix.Parse(this, left, token);
            }

            return left;
        }


        private int PeekPrecedence()
        {
            var next = Peek();
            var parser = GetInfixDenotation(next.Type);
            return parser?.RightBindingPower ?? 0;
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
            return new ParseError($"Error at token {token.Type}: {message}");
        }
    }
}
