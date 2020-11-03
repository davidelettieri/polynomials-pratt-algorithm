using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;

namespace PolynomialsPrattAlgorithm.Parselets
{
    public class ImplicitProductParselet : IInfixParselet
    {
        private readonly int _precedence;
        private readonly Associativity _associativity;
        private readonly VarParselet _varParselet = new VarParselet();
        private readonly NumberParselet _numberParselet = new NumberParselet();
        public ImplicitProductParselet(int precedence, Associativity associativity)
        {
            _precedence = precedence;
            _associativity = associativity;
        }

        public int GetPrecedence() => _precedence;

        public IExpr Parse(Parser parser, IExpr left, Token token)
        {
            return token.Type switch
            {
                VAR => new ProductExpr(left, _varParselet.Parse(parser, token)),
                NUMBER => new ProductExpr(left, _numberParselet.Parse(parser, token)),
                _ => throw new ParseError("Expect a number or a variable")
            };
        }
    }
}
