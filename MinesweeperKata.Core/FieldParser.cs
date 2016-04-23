namespace MinesweeperKata.Core
{
    public class FieldParserResult
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
    }

    public static class FieldParser
    {
        public static FieldParserResult Parse(string input)
        {
            var elements = input.Split(' ');

            return new FieldParserResult
            {
                Lines = int.Parse(elements[0]),
                Columns = int.Parse(elements[1])
            };
        }
    }
}
