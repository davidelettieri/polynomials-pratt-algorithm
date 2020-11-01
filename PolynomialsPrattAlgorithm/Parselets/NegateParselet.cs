using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Parselets
{
    public class NegateParselet : IPrefixParselet
    {
        public IExpr Parse(Parser parser, Token token)
        {
            var operand = parser.ParseExpression(Precedence.PREFIX);

            return new NegateExpr(operand);
        }
    }
}
