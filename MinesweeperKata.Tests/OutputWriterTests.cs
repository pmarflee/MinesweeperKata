using MinesweeperKata.Core;
using MinesweeperKata.Core.Model;
using System.Collections.Generic;
using Xunit;
using static MinesweeperKata.Tests.TestData;

namespace MinesweeperKata.Tests
{
    public class OutputWriterTests
    {
        [Theory, MemberData("Data", MemberType = typeof(TestData))]
        public void ShouldProduceCorrectOutputForField(TestDataItem item)
        {
            Assert.Equal(item.Output, OutputWriter.Write(item.Field));
        }

        [Theory, MemberData("FullOutput", MemberType = typeof(TestData))]
        public void ShouldProduceCorrectOutputForAllFields(IEnumerable<Field> fields, string expected)
        {
            Assert.Equal(expected, OutputWriter.Write(fields));
        }
    }
}
