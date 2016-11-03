using Xunit;

using Algorithms.Strings;

namespace Tests.Strings
{
    public class ComparisonTests : TestBase
    {
        private const string arbString = "arbString";

        [Fact]
        public void CanHandleNullStringsForEditDistance()
        {
            int dist = StringComparison.EditDistance(null, null);

            Assert.True(dist == 0);
        }

        [Fact]
        public void CanHandleNullLeftStringForEditDistance()
        {
            int dist = StringComparison.EditDistance(null, arbString);

            Assert.True(dist == arbString.Length);
        }

        [Fact]
        public void CanHandleNullRightStringForEditDistance()
        {
            int dist = StringComparison.EditDistance(arbString, null);

            Assert.True(dist == arbString.Length);
        }

        [Fact]
        public void ReturnsNoDistanceForEqualStringsForEditDistance()
        {
            int dist = StringComparison.EditDistance(arbString, arbString);

            Assert.True(dist == 0);
        }

        [Fact]
        public void ReturnsCorrectEditDistance()
        {
            int dist = 0;

            dist = StringComparison.EditDistance("hello", "hallo");
            Assert.True(dist == 1);

            dist = StringComparison.EditDistance("hello", "aeloo");
            Assert.True(dist == 2);

            dist = StringComparison.EditDistance("hello", "ehoao");
            Assert.True(dist == 4);

            dist = StringComparison.EditDistance("hello", "ehlo");
            Assert.True(dist == 2);
        }
    }
}