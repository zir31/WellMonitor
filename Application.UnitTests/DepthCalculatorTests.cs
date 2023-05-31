using WellMonitor.Application.Helpers;
using WellMonitor.Core.Entities;

namespace Application.UnitTests
{
    public class DepthCalculatorTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void CalculatePassedDepth(WellEntity well, int expected)
        {
            var actual = well.CalculatePassedDepth();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new WellEntity { Id = 1, Telemetries = new List<TelemetryEntity>() { new TelemetryEntity { Id = 1, Depth = 10}, new TelemetryEntity { Id = 2,Depth = 20  } } }, 10 },
            new object[] { new WellEntity { Id = 1, Telemetries = new List<TelemetryEntity>() { new TelemetryEntity { Id = 1, Depth = 100}, new TelemetryEntity { Id = 2,Depth = 150  } } }, 50 },
            new object[] { new WellEntity { Id = 1, Telemetries = new List<TelemetryEntity>() { new TelemetryEntity { Id = 1, Depth = 200}, new TelemetryEntity { Id = 2,Depth = 289  } } }, 89 }
        };
    }
}
