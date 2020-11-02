using PolynomialsPrattAlgorithm.Expressions;
using System.Collections.Generic;

namespace PolynomialsPrattAlgorithm.Parsing
{
    public class PolynomialEvaluation
    {
        public IExpr Polynomial { get; }
        public Dictionary<char, double> VariableValues { get; }

        public PolynomialEvaluation(IExpr polynomial)
        {
            Polynomial = polynomial;
        }

        public void AddVariableValue(char name, double value) => VariableValues[name] = value;

        public double Eval() => Polynomial.Eval(VariableValues);
    }
}
