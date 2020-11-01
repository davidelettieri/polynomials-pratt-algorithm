using System.Collections.Generic;
using System.Text;

namespace PolynomialsPrattAlgorithm.Expressions
{
    public interface IExpr
    {
        double Eval(Dictionary<char, double> variablesValue);
    }
}
