using MinesweeperKata.Core.Model;
using System.Text;

namespace MinesweeperKata.Core
{
    public static class OutputWriter
    {
        public static string Write(Field field)
        {
            var builder = new StringBuilder();

            for (var line = 0; line < field.Lines; line++)
            {
                var builder2 = new StringBuilder(field.Columns);

                for (var column = 0; column < field.Columns; column++)
                {
                    var countOfAdjacentMines = field.GetCountOfAdjacentMines(line, column);
                    if (countOfAdjacentMines.HasValue)
                    {
                        builder.Append(countOfAdjacentMines);
                    }
                    else
                    {
                        builder.Append('*');
                    }
                }

                builder.Append(builder2.ToString());

                if (line < field.Lines - 1) builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
