using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Denotations
{
    public interface IPrefixDenotation
    {
        IExpr Parse(Parser parser, Token token);
    }
}
