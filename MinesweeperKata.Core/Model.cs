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
        public Field(Header header, Symbol[][] data)
        {
            Lines = header.Lines;
            Columns = header.Columns;
            Data = data;
        }

        public int Lines { get; private set; }
        public int Columns { get; private set; }
        public Symbol[][] Data { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as Field;

            if (other == null) return false;

            return Lines == other.Lines && Columns == other.Columns
                && Data.Length == other.Data.Length
                && Data.Zip(other.Data, (line1, line2) => new { line1, line2 })
                .All(pair => pair.line1.SequenceEqual(pair.line2));
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