using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class NegateExpr : IExpr
    {
        private readonly IExpr _expr;
        public NegateExpr(IExpr expr)
        {
            _expr = expr;
        }

        public double Eval(Dictionary<char, double> variablesValue) => _expr.Eval(variablesValue) * -1;

        public override string ToString()
        {
            return $"Negate({_expr})";
        }
    }
}
