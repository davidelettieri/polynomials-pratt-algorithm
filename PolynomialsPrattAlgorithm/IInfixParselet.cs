using PolynomialsPrattAlgorithm.Expressions;

namespace PolynomialsPrattAlgorithm
{
    public interface IInfixParselet
    {
        IExpr Parse(Parser parser, IExpr left, Token token);
        int GetPrecedence();
    }
}
