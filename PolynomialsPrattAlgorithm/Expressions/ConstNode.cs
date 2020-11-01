using System.Collections.Generic;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class ConstNode : IExpr
    {
        private readonly double _value;
        public ConstNode(double value)
        {
            _value = value;
        }
        public double Eval(Dictionary<char, double> _) => _value;


        public override string ToString()
        {
            return $"{_value}";
        }
    }
}
