using System;
using System.Linq;
using Xunit;

using Algorithms.Searching;

namespace Tests.Searching
{
    public class SearchTests : TestBase
    {
        private const int arbSearchElement = int.MaxValue - 100;

        [Fact]
        public void CanHandleNullSetForBinarySearch()
        {
            Exception error = null;

            try
            {
                Search.BinarySearch<int>(null, arbSearchElement);
            }
            catch (Exception ex) { error = ex; }

            Assert.True(error != null);
            Assert.IsType<ArgumentNullException>(error);
            Assert.True(((ArgumentNullException)error).ParamName == "items");
        }

        [Fact]
        public void CanHandleEmptySetForBinarySearch()
        {
            int index = Search.BinarySearch(new int[] { }, arbSearchElement);

            Assert.True(index == -1);
        }

        [Fact]
        public void CanFindItemInSetWithOneElementForBinarySearch()
        {
            int index = Search.BinarySearch(new int[] { arbSearchElement }, arbSearchElement);

            Assert.True(index == 0);
        }

        [Fact]
        public void CanFindItemInSetWithOddNumberOfItemsForBinarySearch()
        {
            int[] items = new int[] { 1, 5, 8 };

            int index = -1;

            index = Search.BinarySearch(items, 1);
            Assert.True(index == 0);

            index = Search.BinarySearch(items, 8);
            Assert.True(index == items.Length - 1);

            index = Search.BinarySearch(items, 5);
            Assert.True(index == 1);

            index = Search.BinarySearch(items, 9);
            Assert.True(index == -1);

            index = Search.BinarySearch(items, 0);
            Assert.True(index == -1);            
        }

        [Fact]
        public void CanFindItemInSetWithEvenNumberOfItemsForBinarySearch()
        {
            int[] items = new int[] { 1, 5, 8, 9, 12, 15, 21 };

            int index = -1;

            index = Search.BinarySearch(items, 1);
            Assert.True(index == 0);

            index = Search.BinarySearch(items, 21);
            Assert.True(index == items.Length - 1);

            index = Search.BinarySearch(items, 9);
            Assert.True(index == 3);

            index = Search.BinarySearch(items, 12);
            Assert.True(index == 4);

            index = Search.BinarySearch(items, 25);
            Assert.True(index == -1);

            index = Search.BinarySearch(items, 0);
            Assert.True(index == -1);            
        }
    }
}
