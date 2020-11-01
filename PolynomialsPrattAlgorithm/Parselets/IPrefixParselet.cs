using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Parselets
{
    public interface IPrefixParselet
    {
        IExpr Parse(Parser parser, Token token);
    }
}
