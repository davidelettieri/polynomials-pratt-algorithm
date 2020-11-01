using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class AssignExpr
    {
        private readonly VariableExpr _var;
        private readonly ConstNode _value;
        public AssignExpr(VariableExpr variable, ConstNode value)
        {
            _var = variable;
            _value = value;
        }
    }

    public class PolynomialEvaluation
    {
        public IExpr Polinomyal { get; set; }
        public List<AssignExpr> VariableValues { get; set; }
    }
}
