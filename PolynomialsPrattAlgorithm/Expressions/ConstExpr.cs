using System.Collections.Generic;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class ConstExpr : IExpr
    {
        public double Value { get; }
        public ConstExpr(double value)
        {
            Value = value;
        }
        public double Eval(Dictionary<char, double> _) => Value;


        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
