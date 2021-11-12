using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Denotations
{
    public class NegateDenotation : IPrefixDenotation
    {
        public IExpr Parse(Parser parser, Token token)
        {
            var operand = parser.ParseExpression(Precedence.PREFIX);

            return new NegateExpr(operand);
        }
    }
}
