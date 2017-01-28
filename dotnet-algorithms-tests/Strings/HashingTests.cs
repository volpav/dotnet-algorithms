using Xunit;

using Algorithms.Strings;

namespace Tests.Strings
{
    public class HashingTests : TestBase
    {
        private readonly string input = "This is my string";
        private readonly int blockSize = 2;

        [Fact]
        public void ShouldComputeInitialRabinKarpHash()
        {
            var hash = new RabinKarpHash(blockSize, new RandomizedHashCoefficientTable());

            Assert.True(hash.Value == 0);

            hash.Add(input[0]);
            hash.Add(input[1]);

            Assert.True(hash.Value != 0);
        }

        [Fact]
        public void ShouldRollRabinKarpHash()
        {
            var hashes = RabinKarpHash.RollOver(input, blockSize);

            int total = 0;
            int firstOccur = -1, secondOccur = -1;

            foreach (int hash in hashes)
            {
                if (total == 2)
                {
                    firstOccur = hash;
                }
                else if (total == 5)
                {
                    secondOccur = hash;
                }

                total++;
            }

            Assert.True(total == 16);
            Assert.True(firstOccur == secondOccur);
        }
    }
}