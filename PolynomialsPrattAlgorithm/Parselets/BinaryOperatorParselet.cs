using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;

namespace PolynomialsPrattAlgorithm.Parselets
{
    public class BinaryOperatorParselet : IInfixParselet
    {
        private readonly int _precedence;
        private readonly Associativity _associativity;
        public BinaryOperatorParselet(int precedence, Associativity associativity)
        {
            _precedence = precedence;
            _associativity = associativity;
        }

        public int GetPrecedence() => _precedence;

        public IExpr Parse(Parser parser, IExpr left, Token token)
        {
            var parsePrecedence = _precedence - (_associativity == Associativity.Right ? -1 : 0);
            var right = parser.ParseExpression(parsePrecedence);

            return token.Type switch
            {
                VAR => new ProductExpr(left, right),
                NUMBER => new ProductExpr(left, right),
                PLUS => new AddExpr(left, right),
                MINUS => new SubtractExpr(left, right),
                STAR => new ProductExpr(left, right),
                SLASH => new DivideExpr(left, right),
                POWER => new PowerExpr(left, right),
                _ => throw new ParseError("Expect one of '*','/','+','-','^', a number or a variable")
            };
        }
    }
}
