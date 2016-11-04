using Xunit;

using Algorithms.Strings;

namespace Tests.Strings
{
    public class TraversalTests : TestBase
    {
        private const string arbString = "arbString";

        [Fact]
        public void CanHandleNullStringsForEditDistance()
        {
            int dist = StringTraversal.EditDistance(null, null);

            Assert.True(dist == 0);
        }

        [Fact]
        public void CanHandleNullLeftStringForEditDistance()
        {
            int dist = StringTraversal.EditDistance(null, arbString);

            Assert.True(dist == arbString.Length);
        }

        [Fact]
        public void CanHandleNullRightStringForEditDistance()
        {
            int dist = StringTraversal.EditDistance(arbString, null);

            Assert.True(dist == arbString.Length);
        }

        [Fact]
        public void ReturnsNoDistanceForEqualStringsForEditDistance()
        {
            int dist = StringTraversal.EditDistance(arbString, arbString);

            Assert.True(dist == 0);
        }

        [Fact]
        public void ReturnsCorrectEditDistance()
        {
            int dist = 0;

            dist = StringTraversal.EditDistance("hello", "hallo");
            Assert.True(dist == 1);

            dist = StringTraversal.EditDistance("hello", "aeloo");
            Assert.True(dist == 2);

            dist = StringTraversal.EditDistance("hello", "ehoao");
            Assert.True(dist == 4);

            dist = StringTraversal.EditDistance("hello", "ehlo");
            Assert.True(dist == 2);
        }
    }
}