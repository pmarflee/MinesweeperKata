using MinesweeperKata.Core;
using MinesweeperKata.Core.Model;
using System.Collections.Generic;
using Xunit;
using Sprache;
using System.Linq;

namespace MinesweeperKata.Tests
{
    public class FieldParsingTests
    {
        [Theory, MemberData("Headers")]
        public void ShouldParseHeader(string input, Header expected)
        {
            Assert.Equal(expected, FieldParser.Header.Parse(input));
        }

        [Theory, MemberData("FieldLines")]
        public void ShouldParseFieldLine(int columns, string input, Symbol[] expected)
        {
            Assert.Equal(expected, FieldParser.CreateFieldLineParser(columns).Parse(input));
        }

        [Fact]
        public void ShouldThrowParseExceptionParseFieldLineWhenNumberOfColumnsDoesNotMatch()
        {
            Assert.Throws<ParseException>(() => FieldParser.CreateFieldLineParser(4).Parse("..."));
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

        [Fact]
        public void ShouldThrowParseExceptionParseFieldWhenNumberOfLinesDoesNotMatchHeader()
        {
            Assert.Throws<ParseException>(() => FieldParser.Field.Parse("4 3\r\n*...\r\n....\r\n.*..\r\n..*.\r\n"));
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
                    new object[] { 4, "*...", TestData.Data[0].Field.Data[0] },
                    new object[] { 4, "....", TestData.Data[0].Field.Data[1] },
                    new object[] { 4, ".*..", TestData.Data[0].Field.Data[2] },
                    new object[] { 4, "..*.", TestData.Data[0].Field.Data[3] },
                };
            }
        }

        public static IEnumerable<object[]> Fields
        {
            get
            {
                return from item in TestData.Data
                       select new object[] { item.Input, item.Field };
            }
        }

        public static IEnumerable<object[]> FullInput
        {
            get
            {
                string input = string.Empty;
                List<Field> fields = new List<Field>();

                foreach (var item in TestData.Data)
                {
                    input += item.Input;
                    fields.Add(item.Field);
                }

                input += "0 0";

                return new[] { new object[] { input, fields } };
            }
        }
    }
}
