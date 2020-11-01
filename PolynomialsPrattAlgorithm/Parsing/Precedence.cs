namespace PolynomialsPrattAlgorithm.Parsing
{
    public static class Precedence
    {
        public static readonly int SUM = 1;
        public static readonly int PRODUCT = 2;
        public static readonly int EXPONENT = 3;
        public static readonly int PREFIX = 3;
    }
}
