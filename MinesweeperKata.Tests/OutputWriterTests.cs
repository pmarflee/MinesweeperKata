using MinesweeperKata.Core;
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
    }
}
