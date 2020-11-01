using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Parselets
{
    public interface IInfixParselet
    {
        IExpr Parse(Parser parser, IExpr left, Token token);
        int GetPrecedence();
    }
}
