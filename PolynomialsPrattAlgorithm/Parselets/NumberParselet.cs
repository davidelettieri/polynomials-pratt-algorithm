﻿using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;

namespace PolynomialsPrattAlgorithm.Parselets
{
    public class NumberParselet : IPrefixParselet
    {
        public IExpr Parse(Parser parser, Token token)
        {
            return new ConstExpr((double)token.Value);
        }
    }
}
