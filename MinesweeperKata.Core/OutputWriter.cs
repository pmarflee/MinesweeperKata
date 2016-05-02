using MinesweeperKata.Core.Model;
using System.Collections.Generic;
using System.Linq;
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

        public static string Write(IEnumerable<Field> fields)
        {
            var builder = new StringBuilder();
            var fieldsList = fields.ToList();

            for (var i = 0; i < fieldsList.Count; i++)
            {
                builder.AppendLine(string.Format("Field #{0}:", i + 1));
                builder.Append(Write(fieldsList[i]));

                if (i < fieldsList.Count - 1)
                {
                    builder.AppendLine();
                    builder.AppendLine();
                }
            }

            return builder.ToString();
        }
    }
}
