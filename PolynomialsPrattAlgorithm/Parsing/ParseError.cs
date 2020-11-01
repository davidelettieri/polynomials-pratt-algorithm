using System;

namespace PolynomialsPrattAlgorithm.Parsing
{
    public class ParseError : Exception
    {
        public ParseError(string message) : base(message)
        {
        }
    }
}
