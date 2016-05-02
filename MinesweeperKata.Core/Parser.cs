using MinesweeperKata.Core.Model;
using Sprache;
using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata.Core
{
    public static class FieldParser
    {
        internal static readonly Parser<Header> Header =
            from lines in Parse.Number
            from space in Parse.WhiteSpace
            from columns in Parse.Number
            from _ in Parse.LineTerminator
            let numLines = int.Parse(lines)
            let numColumns = int.Parse(columns)
            where numLines > 0 && numColumns > 0
            select new Header(numLines, numColumns);

        internal static readonly Parser<Field> Field =
            from header in Header
            let fieldLineParser = CreateFieldLineParser(header.Columns)
            from data in fieldLineParser.Repeat(header.Lines)
            select new Field(header, data);

        private static readonly Parser<IEnumerable<Field>> AllFields =
            from fields in Field.Many()
            from terminator in Parse.String("0 0")
            select fields;

        internal static Parser<Symbol[]> CreateFieldLineParser(int columns)
        {
            return from chars in 
                Parse.Char('*').Return(Symbol.Mine)
                .Or(Parse.Char('.').Return(Symbol.Blank))
                .Repeat(columns)
            from _ in Parse.LineTerminator
            select chars.ToArray();
        }

        public static IEnumerable<Field> ParseFields(string input)
        {
            return AllFields.Parse(input);
        }
    }
}
