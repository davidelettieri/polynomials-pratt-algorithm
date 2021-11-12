using PolynomialsPrattAlgorithm.Expressions;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Denotations
{
    public class GroupDenotation : IPrefixDenotation
    {
        public IExpr Parse(Parser parser, Token token)
        {
            var expr = parser.ParseExpression();
            parser.Consume(RIGHT_PAREN, "Expecting ')' after expression.");
            return expr;
        }
    }
}
