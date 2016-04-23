using MinesweeperKata.Core;
using Xunit;

namespace MinesweeperKata.Tests
{
    public class FieldParsingTests
    {
        [Theory]
        [InlineData("4 4", 4)]
        [InlineData("3 4", 3)]
        [InlineData("2 4", 2)]
        public void ShouldParseNumberOfLines(string input, int expectedLines)
        {
            var result = FieldParser.Parse(input);

            Assert.Equal(expectedLines, result.Lines);
        }

        [Theory]
        [InlineData("4 4", 4)]
        [InlineData("4 3", 3)]
        [InlineData("4 2", 2)]
        public void ShouldParseNumberOfColumns(string input, int expectedColumns)
        {
            var result = FieldParser.Parse(input);

            Assert.Equal(expectedColumns, result.Columns);
        }
    }
}
