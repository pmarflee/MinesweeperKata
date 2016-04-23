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
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var firstLineElements = lines[0].Split(' ');

            return new FieldParserResult(
                int.Parse(firstLineElements[0]), 
                int.Parse(firstLineElements[1]),
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
