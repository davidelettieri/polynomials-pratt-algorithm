using PolynomialsPrattAlgorithm.Expressions;

namespace PolynomialsPrattAlgorithm
{
    public interface IPrefixParselet
    {
        IExpr Parse(Parser parser, Token token);
    }
}
