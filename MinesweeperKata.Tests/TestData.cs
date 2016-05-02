using MinesweeperKata.Core.Model;

namespace MinesweeperKata.Tests
{
    public static class TestData
    {
        public class TestDataItem
        {
            public string Input { get; set; }
            public Field Field { get; set; }
            public string Output { get; set; }
        }

        public static readonly TestDataItem[] Data = new[]
        {
            new TestDataItem
            {
                Input = "4 4\r\n*...\r\n....\r\n.*..\r\n..*.\r\n",
                Field = new Field(
                            new Header(4, 4),
                            new[]
                            {
                                new[] { Symbol.Mine, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                                new[] { Symbol.Blank, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                                new[] { Symbol.Blank, Symbol.Mine, Symbol.Blank, Symbol.Blank },
                                new[] { Symbol.Blank, Symbol.Blank, Symbol.Mine, Symbol.Blank }
                            }),
                Output = ""
            },
            new TestDataItem
            {
                Input = "3 5\r\n**...\r\n.....\r\n.*...\r\n",
                Field =new Field(
                            new Header(3, 5),
                            new[]
                            {
                                new[] { Symbol.Mine, Symbol.Mine, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                                new[] { Symbol.Blank, Symbol.Blank, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                                new[] { Symbol.Blank, Symbol.Mine, Symbol.Blank, Symbol.Blank, Symbol.Blank },
                            }),
                Output = ""
            }
        };
    }
}
