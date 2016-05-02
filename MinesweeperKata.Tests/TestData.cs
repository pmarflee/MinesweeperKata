using MinesweeperKata.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperKata.Tests
{
    public static class TestData
    {
        public class TestDataItem
        {
            public string HeaderInput { get; set; }
            public string[] LineInput { get; set; }

            public string Input
            {
                get
                {
                    var builder = new StringBuilder();
                    builder.AppendLine(HeaderInput);
                    foreach (var line in LineInput)
                    {
                        builder.AppendLine(line);
                    }

                    return builder.ToString();
                }
            }

            public Field Field { get; set; }
            public string Output { get; set; }
        }

        private static readonly TestDataItem[] Items = new[]
        {
            new TestDataItem
            {
                HeaderInput = "4 4",
                LineInput = new[] { "*...", "....", ".*..", "..*." },
                Field = new Field(
                            new Header(4, 4),
                            new[]
                            {
                                new[] { Symbol.Mine, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                                new[] { Symbol.Blank, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                                new[] { Symbol.Blank, Symbol.Mine, Symbol.Blank, Symbol.Blank },
                                new[] { Symbol.Blank, Symbol.Blank, Symbol.Mine, Symbol.Blank }
                            }),
                Output = "*100\r\n2210\r\n1*10\r\n1110"
            },
            new TestDataItem
            {
                HeaderInput = "3 5",
                LineInput = new[] { "**...", ".....", ".*..." },
                Field =new Field(
                            new Header(3, 5),
                            new[]
                            {
                                new[] { Symbol.Mine, Symbol.Mine, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                                new[] { Symbol.Blank, Symbol.Blank, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                                new[] { Symbol.Blank, Symbol.Mine, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                            }),
                Output = "**100\r\n33200\r\n1*100"
            }
        };

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

        public static IEnumerable<object[]> Data
        {
            get
            {
                return from item in Items
                       select new object[] { item };
            } 
        } 

        public static IEnumerable<object[]> FieldLines
        {
            get
            {
                return from item in Items
                       from pair in item.LineInput.Zip(item.Field.Data, (input, data) => new {input, data})
                       select new object[] { item.Field.Columns, pair.input, pair.data };
            }
        }

        public static IEnumerable<object[]> FullInput
        {
            get
            {
                string input = string.Empty;
                List<Field> fields = new List<Field>();

                foreach (var item in Items)
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
