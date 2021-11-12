using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Denotations
{
    public interface IInfixDenotation
    {
        IExpr Parse(Parser parser, IExpr left, Token token);
        int RightBindingPower { get; }
        int LeftBindingPower { get; }
    }
}
