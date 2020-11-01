using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialsPrattAlgorithm
{
    public static class Polynomials
    {
        public static void Main()
        {
            var source = "(x+y)^2";

            var scanner = new Scanner(source);

            var token = scanner.ScanTokens();
        }
    }
}
