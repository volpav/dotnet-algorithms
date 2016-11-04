using Xunit;

using Algorithms.Misc;

namespace Tests.Misc
{
    public class PatternTests : TestBase
    {
        [Fact]
        public void CanHandleEmptySequenceForIncreasingSubsequenceLength()
        {
            int length = Pattern.LongestIncreasingSubsequenceLength<int>(null);
            Assert.True(length == 0);

            length = Pattern.LongestIncreasingSubsequenceLength(new int[] { });
            Assert.True(length == 0);
        }

        [Fact]
        public void ReturnsCorrectLongestIncreasingSubsequenceLength()
        {
            int length = Pattern.LongestIncreasingSubsequenceLength(new int[] { 4, 1, 3, 2, 1, 0, 4, 5, 6, 9, 10, 7, 8 });
            Assert.True(length == 6);
        }
    }
}