using System.Collections.Generic;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class SubtractExpr : IExpr
    {
        private readonly IExpr _left;
        private readonly IExpr _right;
        public SubtractExpr(IExpr left, IExpr right)
        {
            _left = left;
            _right = right;
        }
        public double Eval(Dictionary<char, double> variablesValue) => _left.Eval(variablesValue) - _right.Eval(variablesValue);


        public override string ToString()
        {
            return $"Subtract({_left},{_right})";
        }
    }
}
