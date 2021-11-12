using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Denotations
{
    public class VarDenotation : IPrefixDenotation
    {
        public IExpr Parse(Parser parser, Token token)
        {
            return new VariableExpr((char)token.Value);
        }
    }
}
