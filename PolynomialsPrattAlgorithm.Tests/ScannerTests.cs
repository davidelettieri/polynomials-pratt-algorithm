using PolynomialsPrattAlgorithm.Parsing;
using System.Globalization;
using Xunit;

namespace PolynomialsPrattAlgorithm.Tests
{
    public class ScannerTests
    {
        [Theory(DisplayName = "Token generation")]
        [InlineData("1234.6", TokenType.NUMBER)]
        [InlineData("1.6", TokenType.NUMBER)]
        [InlineData("10", TokenType.NUMBER)]
        [InlineData("*", TokenType.STAR)]
        [InlineData("+", TokenType.PLUS)]
        [InlineData("-", TokenType.MINUS)]
        [InlineData("/", TokenType.SLASH)]
        [InlineData("x", TokenType.VAR)]
        [InlineData("y", TokenType.VAR)]
        [InlineData("u", TokenType.VAR)]
        [InlineData("(", TokenType.LEFT_PAREN)]
        [InlineData(")", TokenType.RIGHT_PAREN)]
        [InlineData("^", TokenType.POWER)]
        [InlineData("=", TokenType.EQUAL)]
        [InlineData(",", TokenType.COMMA)]
        public void Test1(string source, TokenType token)
        {
            // Arrange
            var parser = new Scanner(source);

            // Act
            var tokens = parser.ScanTokens();

            // Assert
            Assert.Equal(2, tokens.Count);
            Assert.Equal(token, tokens[0].Type);
            Assert.Equal(TokenType.EOF, tokens[1].Type);
        }

        [Theory(DisplayName = "Number tokens")]
        [InlineData(1)]
        [InlineData(1.2)]
        [InlineData(18)]
        [InlineData(10.5678)]
        [InlineData(1789.1)]
        [InlineData(10.0)]
        [InlineData(0)]
        public void Test2(double number)
        {
            // Arrange
            var parser = new Scanner(number.ToString(CultureInfo.InvariantCulture));

            // Act
            var tokens = parser.ScanTokens();

            // Assert
            Assert.IsType<double>(tokens[0].Value);
            Assert.Equal(number, (double)tokens[0].Value);
        }
    }
}
