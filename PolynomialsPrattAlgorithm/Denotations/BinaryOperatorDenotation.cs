using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;

namespace PolynomialsPrattAlgorithm.Denotations
{
    public class BinaryOperatorDenotation : IInfixDenotation
    {
        public int RightBindingPower { get; }
        public int LeftBindingPower { get; }

        public BinaryOperatorDenotation(int bightBindingPower, int leftBindingPower)
        {
            RightBindingPower = bightBindingPower;
            LeftBindingPower = leftBindingPower;
        }

        public IExpr Parse(Parser parser, IExpr left, Token token)
        {
            var right = parser.ParseExpression(LeftBindingPower);

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
