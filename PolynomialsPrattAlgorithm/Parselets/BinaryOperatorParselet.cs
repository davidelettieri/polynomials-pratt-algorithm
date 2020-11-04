using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;

namespace PolynomialsPrattAlgorithm.Parselets
{
    public class BinaryOperatorParselet : IInfixParselet
    {
        public int Precedence { get; }
        private readonly Associativity _associativity;
        public BinaryOperatorParselet(int precedence, Associativity associativity)
        {
            Precedence = precedence;
            _associativity = associativity;
        }

        public IExpr Parse(Parser parser, IExpr left, Token token)
        {
            var parsePrecedence = Precedence - (_associativity == Associativity.Right ? -1 : 0);
            var right = parser.ParseExpression(parsePrecedence);

            return token.Type switch
            {
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
