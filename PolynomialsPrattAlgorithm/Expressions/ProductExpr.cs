using System.Collections.Generic;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class ProductExpr : IExpr
    {
        private readonly IExpr _left;
        private readonly IExpr _right;
        public ProductExpr(IExpr left, IExpr right)
        {
            _left = left;
            _right = right;
        }
        public double Eval(Dictionary<char, double> variablesValue) => _left.Eval(variablesValue) * _right.Eval(variablesValue);

        public override string ToString()
        {
            return $"Product({_left},{_right})";
        }
    }
}
