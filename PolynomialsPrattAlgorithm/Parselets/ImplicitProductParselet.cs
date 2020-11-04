using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;

namespace PolynomialsPrattAlgorithm.Parselets
{
    public class ImplicitProductParselet : IInfixParselet
    {
        public int Precedence { get; }
        private readonly Associativity _associativity;
        private readonly VarParselet _varParselet = new VarParselet();
        private readonly NumberParselet _numberParselet = new NumberParselet();
        public ImplicitProductParselet(int precedence, Associativity associativity)
        {
            Precedence = precedence;
            _associativity = associativity;
        }

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
