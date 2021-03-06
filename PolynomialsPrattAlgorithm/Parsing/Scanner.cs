﻿using System.Collections.Generic;
using System.Globalization;
using static PolynomialsPrattAlgorithm.Parsing.TokenType;

namespace PolynomialsPrattAlgorithm.Parsing
{
    public class Scanner
    {
        private readonly string _source;
        private readonly List<Token> _tokens = new List<Token>();
        private int _start = 0;
        private int _current = 0;

        public Scanner(string source)
        {
            _source = source;
        }

        public List<Token> ScanTokens()
        {
            while (!IsAtEnd())
            {
                _start = _current;
                ScanToken();
            }

            AddToken(EOF);

            return _tokens;
        }

        private void ScanToken()
        {
            var c = Advance();

            switch (c)
            {
                case '(':
                    AddToken(LEFT_PAREN);
                    break;
                case ')':
                    AddToken(RIGHT_PAREN);
                    break;
                case '*':
                    AddToken(STAR);
                    break;
                case '+':
                    AddToken(PLUS);
                    break;
                case '-':
                    AddToken(MINUS);
                    break;
                case '/':
                    AddToken(SLASH);
                    break;
                case '^':
                    AddToken(POWER);
                    break;
                case ',':
                    AddToken(COMMA);
                    break;
                case '=':
                    AddToken(EQUAL);
                    break;
                case ' ':
                case '\t':
                case '\n':
                    break;
                default:
                    if (IsDigit(c))
                    {
                        Number();
                    }
                    else
                    {
                        Variable();
                    }
                    break;
            }
        }

        private void Variable()
        {
            AddToken(VAR, _source[_current - 1]);
        }

        private void Number()
        {
            while (IsDigit(Peek())) Advance();

            if (Peek() == '.' && IsDigit(PeekNext()))
            {
                Advance();

                while (IsDigit(Peek())) Advance();
            }

            AddToken(NUMBER, double.Parse(_source.Substring(_start, _current - _start), CultureInfo.InvariantCulture));
        }

        private char Peek()
        {
            if (IsAtEnd())
            {
                return '\0';
            }

            return _source[_current];
        }

        private char PeekNext()
        {
            if (_current + 1 >= _source.Length) return '\0';

            return _source[_current + 1];
        }

        private bool IsDigit(char c) => char.IsDigit(c);

        private void AddToken(TokenType type, object value = null)
        {
            var lexeme = _source.Substring(_start, _current - _start);
            _tokens.Add(new Token(type, _start, lexeme, value));
        }

        private bool IsAtEnd() => _current >= _source.Length;

        private char Advance()
        {
            _current++;
            return _source[_current - 1];
        }
    }
}
