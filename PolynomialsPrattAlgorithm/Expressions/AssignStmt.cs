using System;
using System.Collections.Generic;
using System.Text;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class AssignStmt 
    {
        private readonly VariableExpr _var;
        private readonly ConstExpr _value;
        public AssignStmt(VariableExpr variable, ConstExpr value)
        {
            _var = variable;
            _value = value;
        }
    }
}
