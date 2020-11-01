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
            Console.WriteLine("Test the polynomial evaluation");
            Console.WriteLine("Insert a polynomial and the variable values separated with a comma");
            Console.WriteLine("Eg. x+y^2,x=1,y=2");

            while (true)
            {
                Console.Write("> ");
                var source = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(source))
                {
                    break;
                }
                var scanner = new Scanner(source);
                var tokens = scanner.ScanTokens();
                var parser = new PolynomialsParser(tokens);
                var expr = parser.ParsePolynomialEvaluation();
                Console.WriteLine("> Result is: {0}", expr.Eval());
                Console.WriteLine();
                Console.WriteLine("Try again or Ctrl+c to exit");
            }
            Console.WriteLine("Goodbye!");
        }
    }
}
