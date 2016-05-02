using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata.Core.Model
{
    public enum Symbol
    {
        Blank = 0,
        Mine = 1
    }

    public class Header
    {
        public Header(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
        }

        public int Lines { get; private set; }
        public int Columns { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as Header;

            if (other == null) return false;

            return Lines == other.Lines && Columns == other.Columns;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;
                // Suitable nullity checks etc, of course :)
                hash = (hash * 16777619) ^ Lines.GetHashCode();
                hash = (hash * 16777619) ^ Columns.GetHashCode();
                return hash;
            }
        }
    }

    public class Field
    {
        public Field(Header header, IEnumerable<Symbol[]> data)
        {
            Lines = header.Lines;
            Columns = header.Columns;
            Data = new Symbol[Lines,Columns];

            foreach (var pair in data.Select((line, i) => new { i, line }))
            {
                for (int j = 0; j < Columns; j++)
                {
                    Data[pair.i, j] = pair.line[j];
                }
            }
        }

        public int Lines { get; private set; }
        public int Columns { get; private set; }
        public Symbol[,] Data { get; private set; }

        public int? GetCountOfAdjacentMines(int line, int column)
        {
            if (Data[line, column] == Symbol.Mine) return null;

            var offsets = new[] { -1, 0, 1 };
            var positionsToCheck = from lineOffset in offsets
                                     from columnOffset in offsets
                                     where !(lineOffset == 0 && columnOffset == 0)
                                     let lineToCheck = line + lineOffset
                                     let columnToCheck = column + columnOffset
                                     where lineToCheck >= 0 && lineToCheck < Lines
                                     && columnToCheck >= 0 && columnToCheck < Columns
                                     select new { Line = lineToCheck, Column = columnToCheck };

            return positionsToCheck.Count(position => Data[position.Line, position.Column] == Symbol.Mine);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Field;

            if (other == null) return false;

            return Lines == other.Lines && Columns == other.Columns
                && Data.Length == other.Data.Length
                && Data.Rank == other.Data.Rank 
                && Enumerable.Range(0, Data.Rank).All(dimension => Data.GetLength(dimension) == other.Data.GetLength(dimension)) 
                && Data.Cast<Symbol>().SequenceEqual(other.Data.Cast<Symbol>());
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;
                // Suitable nullity checks etc, of course :)
                hash = (hash * 16777619) ^ Lines.GetHashCode();
                hash = (hash * 16777619) ^ Columns.GetHashCode();
                hash = (hash * 16777619) ^ Data.GetHashCode();
                return hash;
            }
        }
    }
}