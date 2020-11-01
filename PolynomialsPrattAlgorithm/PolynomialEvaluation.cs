using PolynomialsPrattAlgorithm.Expressions;
using System.Collections.Generic;

namespace PolynomialsPrattAlgorithm
{
    public class PolynomialEvaluation
    {
        private readonly IExpr _polynomial;
        private readonly Dictionary<char, double> _variableValues = new Dictionary<char, double>();

        public PolynomialEvaluation(IExpr polynomial)
        {
            _polynomial = polynomial;
        }

        public void AddVariableValue(char name, double value) => _variableValues[name] = value;

        public double Eval() => _polynomial.Eval(_variableValues);
    }
}
