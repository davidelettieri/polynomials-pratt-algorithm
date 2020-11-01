using System.Collections.Generic;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class GroupExpr : IExpr
    {
        private readonly IExpr _expr;
        public GroupExpr(IExpr expr)
        {
            _expr = expr;
        }

        public double Eval(Dictionary<char, double> variablesValue) => _expr.Eval(variablesValue);

        public override string ToString()
        {
            return $"Group({_expr})";
        }
    }
}
