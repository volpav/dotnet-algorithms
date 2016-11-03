using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class MinHeap<T>
    {
        private readonly List<T> _heap;
        private readonly Comparison<T> _comparison;

        public int Count
        {
            get { return _heap.Count; }
        }

        public MinHeap(Comparison<T> comparison)
        {
            _heap = new List<T>();
            _comparison = comparison;
        }

        public void Add(T item)
        {
            _heap.Add(item);

            int i = _heap.Count - 1;

            while (i > 0)
            {
                int j = (i + 1) / 2 - 1;

                T k = _heap[j];
                int res = _comparison(k, _heap[i]);

                if (res <= 0)
                {
                    break;
                }

                Swap(i, j);

                i = j;
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            } 
        }

        public T PeekMin()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("Empty heap.");
            }

            return _heap[0];
        }
        
        public T ExtractMin()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("Empty heap.");
            }
            
            int i = _heap.Count - 1;
            T min = _heap[0];

            _heap[0] = _heap[i];
            _heap.RemoveAt(i);

            HeapifyAdd(0);

            return min;
        }

        private void HeapifyAdd(int n)
        {
            int smallest;
            int l = 2 * (n + 1) - 1;
            int r = 2 * (n + 1) - 1 + 1;
            
            if (l < _heap.Count && (_comparison(_heap[l], _heap[n]) <= 0)) smallest = l;
            else smallest = n;
            
            if (r < _heap.Count && (_comparison(_heap[r], _heap[smallest]) <= 0)) smallest = r;
            
            if (smallest != n)
            {
                Swap(n, smallest);
                
                HeapifyAdd(smallest);
            }
        }

        private void Swap(int i, int j)
        {
            T temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }
    }
}

