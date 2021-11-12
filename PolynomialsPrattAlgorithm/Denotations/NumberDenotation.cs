using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Denotations
{
    public class NumberDenotation : IPrefixDenotation
    {
        public IExpr Parse(Parser parser, Token token)
        {
            return new ConstExpr((double)token.Value);
        }
    }
}
