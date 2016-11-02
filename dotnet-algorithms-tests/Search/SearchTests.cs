using System;
using System.Linq;
using Xunit;

namespace Tests.Search
{
    public class SearchTests : TestBase
    {
        [Fact]
        public void CanHandleNullSetForBinarySearch()
        {
            Exception error = null;

            try
            {
                Algorithms.Search.Search.BinarySearch<int>(null, -1);
            }
            catch (Exception ex) { error = ex; }

            Assert.True(error != null);
            Assert.IsType<ArgumentNullException>(error);
            Assert.True(((ArgumentNullException)error).ParamName == "items");
        }
    }
}
