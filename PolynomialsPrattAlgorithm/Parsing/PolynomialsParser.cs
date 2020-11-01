using PolynomialsPrattAlgorithm.Parselets;
using System.Collections.Generic;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;

namespace PolynomialsPrattAlgorithm.Parsing
{
    public class PolynomialsParser : Parser
    {
        public PolynomialsParser(List<Token> tokens) : base(tokens)
        {
            Register(NUMBER, new NumberParselet());
            Register(VAR, new VarParselet());
            Register(LEFT_PAREN, new GroupParselet());
            Register(MINUS, new NegateParselet());
            Register(PLUS, new BinaryOperatorParselet(Precedence.SUM, Associativity.Left));
            Register(MINUS, new BinaryOperatorParselet(Precedence.SUM, Associativity.Left));
            Register(STAR, new BinaryOperatorParselet(Precedence.PRODUCT, Associativity.Left));
            Register(SLASH, new BinaryOperatorParselet(Precedence.PRODUCT, Associativity.Left));
            Register(POWER, new BinaryOperatorParselet(Precedence.EXPONENT, Associativity.Right));
        }
    }
}
