using MinesweeperKata.Core;
using MinesweeperKata.Core.Model;
using System.Collections.Generic;
using Xunit;
using Sprache;

namespace MinesweeperKata.Tests
{
    public class FieldParsingTests
    {
        private static readonly Field[] _fields = new[]
        {
            new Field(
                new Header(4, 4),
                new[]
                {
                    new[] { Symbol.Mine, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                    new[] { Symbol.Blank, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                    new[] { Symbol.Blank, Symbol.Mine, Symbol.Blank, Symbol.Blank },
                    new[] { Symbol.Blank, Symbol.Blank, Symbol.Mine, Symbol.Blank }
                }),
            new Field(
                new Header(3, 5),
                new[]
                {
                    new[] { Symbol.Mine, Symbol.Mine, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                    new[] { Symbol.Blank, Symbol.Blank, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                    new[] { Symbol.Blank, Symbol.Mine, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                })
        };

        [Theory, MemberData("Headers")]
        public void ShouldParseHeader(string input, Header expected)
        {
            Assert.Equal(expected, FieldParser.Header.Parse(input));
        }

        [Theory, MemberData("FieldLines")]
        public void ShouldParseFieldLine(string input, Symbol[] expected)
        {
            Assert.Equal(expected, FieldParser.FieldLine.Parse(input));
        }

        [Theory, MemberData("Fields")]
        public void ShouldParseField(string input, Field expected)
        {
            Assert.Equal(expected, FieldParser.Field.Parse(input));
        }

        [Theory, MemberData("FullInput")]
        public void ShouldParseFullInput(string input, IEnumerable<Field> expected)
        {
            Assert.Equal(expected, FieldParser.ParseFields(input));
        }

        public static IEnumerable<object[]> Headers
        {
            get
            {
                return new[]
                {
                    new object[] { "4 4\r\n", new Header(4, 4) },
                    new object[] { "3 4\r\n", new Header(3, 4) },
                    new object[] { "2 4\r\n", new Header(2, 4) },
                    new object[] { "4 3\r\n", new Header(4, 3) },
                    new object[] { "4 2\r\n", new Header(4, 2) }
                };
            }
        }

        public static IEnumerable<object[]> FieldLines
        {
            get
            {
                return new[]
                {
                    new object[] { "*...", _fields[0].Data[0] },
                    new object[] { "....", _fields[0].Data[1] },
                    new object[] { ".*..", _fields[0].Data[2] },
                    new object[] { "..*.", _fields[0].Data[3] },
                };
            }
        }

        public static IEnumerable<object[]> Fields
        {
            get
            {
                return new[]
                {
                    new object[] { "4 4\r\n*...\r\n....\r\n.*..\r\n..*.\r\n", _fields[0] },
                    new object[] { "3 5\r\n**...\r\n.....\r\n.*...\r\n", _fields[1] }
                };
            }
        }

        public static IEnumerable<object[]> FullInput
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        "4 4\r\n*...\r\n....\r\n.*..\r\n..*.\r\n3 5\r\n**...\r\n.....\r\n.*...\r\n0 0",
                        _fields
                    }
                };
            }
        }
    }
}
