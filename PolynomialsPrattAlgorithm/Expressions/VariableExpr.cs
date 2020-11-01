using System;
using System.Collections.Generic;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class VariableExpr : IExpr
    {
        private readonly char _var;

        public VariableExpr(char variable)
        {
            _var = variable;
        }
        public double Eval(Dictionary<char, double> variablesValue)
        {
            if (variablesValue.TryGetValue(_var, out var value))
                return value;

            throw new InvalidOperationException($"Value for variable {_var} is not present in dictionary {nameof(variablesValue)}");
        }

        public override string ToString()
        {
            return $"{_var}";
        }
    }
}
