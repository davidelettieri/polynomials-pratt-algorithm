using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Parselets
{
    public class VarParselet : IPrefixParselet
    {
        public IExpr Parse(Parser parser, Token token)
        {
            return new VariableExpr((char)token.Value);
        }
    }
}
