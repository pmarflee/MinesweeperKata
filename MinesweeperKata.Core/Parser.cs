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

        internal static readonly Parser<Symbol[]> FieldLine =
            from chars in 
                Parse.Char('*').Return(Symbol.Mine)
                .Or(Parse.Char('.').Return(Symbol.Blank))
                .Many()
            from _ in Parse.LineTerminator
            select chars.ToArray();

        internal static readonly Parser<Field> Field =
            from header in Header
            from data in FieldLine.Many()
            select new Field(header, data.ToArray());

        private static readonly Parser<IEnumerable<Field>> AllFields =
            from fields in Field.Many()
            from terminator in Parse.String("0 0")
            select fields;

        public static IEnumerable<Field> ParseFields(string input)
        {
            return AllFields.Parse(input);
        }
    }
}
