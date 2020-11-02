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
        [Theory]
        [InlineData("x+y", typeof(AddExpr))]
        [InlineData("x*y", typeof(ProductExpr))]
        [InlineData("x-y", typeof(SubtractExpr))]
        [InlineData("x^y", typeof(PowerExpr))]
        [InlineData("5", typeof(ConstExpr))]
        [InlineData("x", typeof(VariableExpr))]
        [InlineData("xy", typeof(ProductExpr))]
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

    }
}
