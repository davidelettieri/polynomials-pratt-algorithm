using PolynomialsPrattAlgorithm.Expressions;
using PolynomialsPrattAlgorithm.Parsing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PolynomialsPrattAlgorithm.Tests
{
    public class ParserTests
    {
        [Theory(DisplayName = "Parsing simple polynomials")]
        [InlineData("(xy)", typeof(GroupExpr))]
        // [InlineData("x+y", typeof(AddExpr))]
        // [InlineData("x*y", typeof(ProductExpr))]
        // [InlineData("x-y", typeof(SubtractExpr))]
        // [InlineData("x^y", typeof(PowerExpr))]
        // [InlineData("5", typeof(ConstExpr))]
        // [InlineData("x", typeof(VariableExpr))]
        // [InlineData("xy", typeof(ProductExpr))]
        public void Test(string source, Type type)
        {
            // Arrange
            var scanner = new Scanner(source);
            var tokens = scanner.ScanTokens();
            var parser = new Parser(tokens);

            // Act
            var result = parser.ParsePolynomialEvaluation();

            // Assert
            Assert.IsType(type, result.Polynomial);
        }

        [Theory(DisplayName = "Evaluating polynomials")]
        [InlineData("(xy)^2, x=2, y=2", 16)]
        [InlineData("x+y+2, x=2, y=2", 6)]
        [InlineData("(x+1)^2, x=3", 16)]
        [InlineData("x^2+5x+1, x=10", 151)]
        [InlineData("30x, x=2", 60)]
        [InlineData("y-2, y=1", -1)]
        public void Test2(string source, double expected)
        {
            // Arrange
            var scanner = new Scanner(source);
            var tokens = scanner.ScanTokens();
            var parser = new Parser(tokens);
            var polynomial = parser.ParsePolynomialEvaluation();

            // Act
            var result = polynomial.Eval();

            // Assert
            Assert.Equal(expected, result);
        }

    }
}
