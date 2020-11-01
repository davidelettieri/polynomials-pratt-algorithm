using System;
using System.Collections.Generic;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public class PowerExpr : IExpr
    {
        public readonly IExpr _base;
        public readonly IExpr _power;
        public PowerExpr(IExpr @base, IExpr power)
        {
            _base = @base;
            _power = power;
        }

        public double Eval(Dictionary<char, double> variablesValue)
        {
            return Math.Pow(_base.Eval(variablesValue), _power.Eval(variablesValue));
        }

        public override string ToString()
        {
            return $"Pow({_base},{_power})";
        }
    }
}
