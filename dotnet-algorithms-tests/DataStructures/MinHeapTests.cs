using System;

using Xunit;

using Algorithms.IO;
using Algorithms.DataStructures;

namespace Tests.DataStructures
{
    public class MinHeapTests : TestBase
    {
        [Fact]
        public void CanReturnMinimumElements()
        {
            var heap = new MinHeap<int>((x, y) => x - y);

            heap.Add(5);
            heap.Add(3);
            heap.Add(1);
            heap.Add(11);
            heap.Add(2);

            Assert.True(heap.ExtractMin() == 1);
            Assert.True(heap.ExtractMin() == 2);
            Assert.True(heap.ExtractMin() == 3);
            Assert.True(heap.ExtractMin() == 5);
            Assert.True(heap.ExtractMin() == 11);
            Assert.True(heap.Count == 0);
        }

        [Fact]
        public void CanUseCustomComparison()
        {
            var priorities = new int[] { 5, 4, 3, 2, 1 };

            var heap = new MinHeap<int>((x, y) => priorities[x] - priorities[y]);

            heap.AddRange(new int[] { 0, 1, 2, 3, 4 });

            Assert.True(heap.ExtractMin() == 4);
            Assert.True(heap.ExtractMin() == 3);
            Assert.True(heap.ExtractMin() == 2);
            Assert.True(heap.ExtractMin() == 1);
            Assert.True(heap.ExtractMin() == 0);
            Assert.True(heap.Count == 0);
        }
    }
}