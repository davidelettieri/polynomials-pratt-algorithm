using PolynomialsPrattAlgorithm.Parsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialsPrattAlgorithm
{
    public static class PolynomialsPrattAlgorithm
    {
        public static void Main()
        {
            var source = "(x+y)^2,x=2,y=1";

            var scanner = new Scanner(source);

            var tokens = scanner.ScanTokens();

            var parser = new PolynomialsParser(tokens);
            var expr = parser.ParseExpression();
            var result = expr.Eval(new Dictionary<char, double>() { { 'x', 1 }, { 'y', 2 } });
        }
    }
}
