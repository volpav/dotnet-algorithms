using System;
using System.Linq;
using Xunit;

using Algorithms.Sorting;

namespace Tests.Sorting
{
    public class SortTests : TestBase
    {
        private const int arbSortElement = int.MaxValue - 100;

        [Fact]
        public void CanHandleNullSetForQuickSort()
        {
            Exception error = null;

            try
            {
                Sort.QuickSort<int>(null);
            }
            catch (Exception ex) { error = ex; }

            Assert.True(error != null);
            Assert.IsType<ArgumentNullException>(error);
            Assert.True(((ArgumentNullException)error).ParamName == "items");
        }

        [Fact]
        public void CanHandleEmptySetForQuickSort()
        {
            int[] items = new int[] { };

            Sort.QuickSort(items);

            Assert.True(items.Length == 0);
        }

        [Fact]
        public void CanHandleSingleItemSetForQuickSort()
        {
            int[] items = new int[] { arbSortElement };
            
            Sort.QuickSort(items);

            Assert.True(items.Length == 1);
            Assert.True(items[0] == arbSortElement);
        }

        [Fact]
        public void CanSortItemSetForQuickSort()
        {
            int[] items = new int[] { 8, 1, 4, 3, 2, 9, 6, 4, 0 };

            Sort.QuickSort(items);

            Assert.True(items.Length == 9);
            Assert.True(items[0] == 0);
            Assert.True(items[1] == 1);
            Assert.True(items[2] == 2);
            Assert.True(items[3] == 3);
            Assert.True(items[4] == 4);
            Assert.True(items[5] == 4);
            Assert.True(items[6] == 6);
            Assert.True(items[7] == 8);
            Assert.True(items[8] == 9);
        }

        [Fact]
        public void CanHandleNullSetForMergeSort()
        {
            Exception error = null;

            try
            {
                Sort.MergeSort<int>(null);
            }
            catch (Exception ex) { error = ex; }

            Assert.True(error != null);
            Assert.IsType<ArgumentNullException>(error);
            Assert.True(((ArgumentNullException)error).ParamName == "items");
        }

        [Fact]
        public void CanHandleEmptySetForMergeSort()
        {
            int[] items = new int[] { };

            Sort.MergeSort(items);

            Assert.True(items.Length == 0);
        }

        [Fact]
        public void CanHandleSingleItemSetForMergeSort()
        {
            int[] items = new int[] { arbSortElement };
            
            Sort.MergeSort(items);

            Assert.True(items.Length == 1);
            Assert.True(items[0] == arbSortElement);
        }

        [Fact]
        public void CanSortItemSetForMergeSort()
        {
            int[] items = new int[] { 8, 1, 4, 3, 2, 9, 6, 4, 0 };

            Sort.MergeSort(items);

            Assert.True(items.Length == 9);
            Assert.True(items[0] == 0);
            Assert.True(items[1] == 1);
            Assert.True(items[2] == 2);
            Assert.True(items[3] == 3);
            Assert.True(items[4] == 4);
            Assert.True(items[5] == 4);
            Assert.True(items[6] == 6);
            Assert.True(items[7] == 8);
            Assert.True(items[8] == 9);
        }
    }
}