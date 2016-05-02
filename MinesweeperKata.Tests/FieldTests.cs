using MinesweeperKata.Core.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MinesweeperKata.Tests
{
    public class FieldTests
    {
        [Theory, MemberData("CountOfAdjacentMineTestData")]
        public void ShouldCalculateCorrectNumberOfAdjacentMines(Field field, int line, int column, int? expected)
        {
            Assert.Equal(expected, field.GetCountOfAdjacentMines(line, column));
        }

        public static IEnumerable<object[]> CountOfAdjacentMineTestData
        {
            get
            {
                return from item in TestData.Items
                       let field = item.Field
                       from line in Enumerable.Range(0, field.Lines)
                       from column in Enumerable.Range(0, field.Columns)
                       select new object[] { field, line, column, item.MineCounts[line, column] };
            }
        }
    }
}
