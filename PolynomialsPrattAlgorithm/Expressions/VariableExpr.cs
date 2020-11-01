using System;
using System.Collections.Generic;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class VariableExpr : IExpr
    {
        public char Name { get; }

        public VariableExpr(char variable)
        {
            Name = variable;
        }
        public double Eval(Dictionary<char, double> variablesValue)
        {
            if (variablesValue.TryGetValue(Name, out var value))
                return value;

            throw new InvalidOperationException($"Value for variable {Name} is not present in dictionary {nameof(variablesValue)}");
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
