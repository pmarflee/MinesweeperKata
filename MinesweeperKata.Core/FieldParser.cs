using MinesweeperKata.Core.Enums;
using System;
using System.Linq;

namespace MinesweeperKata.Core
{
    public class FieldParserResult
    {
        public FieldParserResult(int numberOfLines, int numberOfColumns, Token[][] lines)
        {
            NumberOfLines = numberOfLines;
            NumberOfColumns = numberOfColumns;
            Lines = lines;
        }

        public int NumberOfLines { get; private set; }
        public int NumberOfColumns { get; private set; }
        public Token[][] Lines { get; private set; }
    }

    public static class FieldParser
    {
        public static FieldParserResult Parse(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var firstLineElements = lines[0].Split(' ');
            int numberOfLines = 0, numberOfColumns = 0;

            if (firstLineElements.Length > 0)
            {
                int.TryParse(firstLineElements[0], out numberOfLines);
            }
            if (firstLineElements.Length > 1)
            {
                int.TryParse(firstLineElements[1], out numberOfColumns);
            }

            return new FieldParserResult(
                numberOfLines, 
                numberOfColumns,
                lines.Skip(1).Select(ParseLine).ToArray());
        }

        private static Token[] ParseLine(string line)
        {
            return line.Select(c =>
            {
                switch (c)
                {
                    case '*':
                        return Token.Mine;
                    case '.':
                        return Token.Blank;
                    default:
                        throw new ArgumentOutOfRangeException(
                            "Invalid character found.  Expected either '*' or '.'", 
                            (Exception)null);
                }
            }).ToArray();
        }
    }
}
