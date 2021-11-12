using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;

namespace PolynomialsPrattAlgorithm.Denotations
{
    public class ImplicitProductDenotation : IInfixDenotation
    {
        public int RightBindingPower { get; }
        public int LeftBindingPower { get; }
        private readonly VarDenotation _varDenotation = new VarDenotation();
        private readonly NumberDenotation _numberDenotation = new NumberDenotation();
        public ImplicitProductDenotation(int precedence, int leftBindingPower)
        {
            RightBindingPower = precedence;
            LeftBindingPower = leftBindingPower;
        }

        public IExpr Parse(Parser parser, IExpr left, Token token)
        {
            return token.Type switch
            {
                VAR => new ProductExpr(left, _varDenotation.Parse(parser, token)),
                NUMBER => new ProductExpr(left, _numberDenotation.Parse(parser, token)),
                _ => throw new ParseError("Expect a number or a variable")
            };
        }
    }
}
