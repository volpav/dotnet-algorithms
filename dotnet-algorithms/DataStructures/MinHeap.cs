using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Represents a binary heap with support for extracting minimum values.
    /// </summary>
    public class MinHeap<T>
    {
        private readonly List<T> heap;
        private readonly Comparison<T> comparison;

        /// <summary>
        /// Gets the number of elements currently in the heap.
        /// </summary>
        public int Count
        {
            get { return heap.Count; }
        }

        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        /// <param name="comparison">Custom comparison.</param>
        public MinHeap(Comparison<T> comparison)
        {
            this.heap = new List<T>();
            this.comparison = comparison;
        }

        /// <summary>
        /// Adds new item to the heap.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public void Add(T item)
        {
            heap.Add(item);

            int i = heap.Count - 1;

            while (i > 0)
            {
                int j = (i + 1) / 2 - 1;

                var k = heap[j];
                var res = comparison(k, heap[i]);

                if (res <= 0)
                {
                    break;
                }

                Swap(i, j);

                i = j;
            }
        }

        /// <summary>
        /// Adds the given items to the queue.
        /// </summary>
        /// <param name="items">Items to add.</param>
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items) Add(item);
        }

        /// <summary>
        /// Returns the minimum element without removing from the heap.
        /// </summary>
        /// <exception cref="InvalidOperationException">Occurs if the heap is empty.</exception>
        public T PeekMin()
        {
            if (heap.Count > 0)
            {
                return heap[0];
            }
            else throw new InvalidOperationException("Empty heap.");
            
        }
        
        /// <summary>
        /// Returns the minimum element and removes it from the heap.
        /// </summary>
        /// <exception cref="InvalidOperationException">Occurs if the heap is empty.</exception>
        public T ExtractMin()
        {
            if (heap.Count > 0)
            {
                int i = heap.Count - 1;

                T min = heap[0];

                heap[0] = heap[i];
                heap.RemoveAt(i);

                HeapifyAdd(0);

                return min;
            }
            else throw new InvalidOperationException("Empty heap.");
        }

        /// <summary>
        /// Rebuilds heap structure.
        /// </summary>
        private void HeapifyAdd(int n)
        {
            int smallest;
            int l = 2 * (n + 1) - 1;
            int r = 2 * (n + 1) - 1 + 1;
            
            if (l < heap.Count && (comparison(heap[l], heap[n]) <= 0)) smallest = l;
            else smallest = n;
            
            if (r < heap.Count && (comparison(heap[r], heap[smallest]) <= 0)) smallest = r;
            
            if (smallest != n)
            {
                Swap(n, smallest);
                
                this.HeapifyAdd(smallest);
            }
        }

        /// <summary>
        /// Swaps two elements in a underlying heap array.
        /// </summary>
        /// <param name="i">Index of a first element.</param>
        /// <param name="j">Index of a second element.</param>
        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}

