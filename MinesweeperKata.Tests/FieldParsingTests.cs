using MinesweeperKata.Core;
using MinesweeperKata.Core.Model;
using System.Collections.Generic;
using Xunit;
using Sprache;
using static MinesweeperKata.Tests.TestData;

namespace MinesweeperKata.Tests
{
    public class FieldParsingTests
    {
        [Theory, MemberData("Headers", MemberType = typeof(TestData))]
        public void ShouldParseHeader(string input, Header expected)
        {
            Assert.Equal(expected, FieldParser.Header.Parse(input));
        }

        [Theory, MemberData("FieldLines", MemberType = typeof(TestData))]
        public void ShouldParseFieldLine(int columns, string input, Symbol[] expected)
        {
            Assert.Equal(expected, FieldParser.CreateFieldLineParser(columns).Parse(input));
        }

        [Fact]
        public void ShouldThrowParseExceptionParseFieldLineWhenNumberOfColumnsDoesNotMatch()
        {
            Assert.Throws<ParseException>(() => FieldParser.CreateFieldLineParser(4).Parse("..."));
        }

        [Theory, MemberData("Data", MemberType = typeof(TestData))]
        public void ShouldParseField(TestDataItem item)
        {
            Assert.Equal(item.Field, FieldParser.Field.Parse(item.Input));
        }

        [Theory, MemberData("FullInput", MemberType = typeof(TestData))]
        public void ShouldParseFullInput(string input, IEnumerable<Field> expected)
        {
            Assert.Equal(expected, FieldParser.ParseFields(input));
        }

        [Fact]
        public void ShouldThrowParseExceptionParseFieldWhenNumberOfLinesDoesNotMatchHeader()
        {
            Assert.Throws<ParseException>(() => FieldParser.Field.Parse("4 3\r\n*...\r\n....\r\n.*..\r\n..*.\r\n"));
        }
    }
}
