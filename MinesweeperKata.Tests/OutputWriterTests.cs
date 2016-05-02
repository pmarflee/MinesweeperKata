using MinesweeperKata.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
