using MinesweeperKata.Core;
using MinesweeperKata.Core.Enums;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace MinesweeperKata.Tests
{
    public class FieldParsingTests
    {
        [Theory]
        [InlineData("4 4", 4)]
        [InlineData("3 4", 3)]
        [InlineData("2 4", 2)]
        [InlineData("4", 4)]
        [InlineData("", 0)]
        public void ShouldParseNumberOfLines(string input, int expectedLines)
        {
            var result = FieldParser.Parse(input);

            Assert.Equal(expectedLines, result.NumberOfLines);
        }

        [Theory]
        [InlineData("4 4", 4)]
        [InlineData("4 3", 3)]
        [InlineData("4 2", 2)]
        [InlineData("2", 0)]
        public void ShouldParseNumberOfColumns(string input, int expectedColumns)
        {
            var result = FieldParser.Parse(input);

            Assert.Equal(expectedColumns, result.NumberOfColumns);
        }

        [Theory, MemberData("LineData")]
        public void ShouldParseLines(string input, Token?[][] expectedLines)
        {
            var result = FieldParser.Parse(input);

            Assert.Equal(expectedLines, result.Lines);
        }

        public static IEnumerable<object[]> LineData
        {
            get
            {
                return new[]
                {
                    new object[] 
                    {
                        "0 0\r\n*...\r\n....\r\n.*..\r\n....",
                        new[] 
                        {
                            new Token?[] { Token.Mine, Token.Blank, Token.Blank, Token.Blank },
                            new Token?[] { Token.Blank, Token.Blank, Token.Blank, Token.Blank },
                            new Token?[] { Token.Blank, Token.Mine, Token.Blank, Token.Blank },
                            new Token?[] { Token.Blank, Token.Blank, Token.Blank, Token.Blank },
                        }
                    },
                    new object[]
                    {
                        "0 0\r\n*.. \r\n....\r\n.*..\r\n....",
                        new[]
                        {
                            new Token?[] { Token.Mine, Token.Blank, Token.Blank, (Token?)null },
                            new Token?[] { Token.Blank, Token.Blank, Token.Blank, Token.Blank },
                            new Token?[] { Token.Blank, Token.Mine, Token.Blank, Token.Blank },
                            new Token?[] { Token.Blank, Token.Blank, Token.Blank, Token.Blank },
                        }
                    }
                };
            }
        }
    }
}
