using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class MinHeap<T>
    {
        private readonly List<T> _heap;
        private readonly Comparison<T> _comparison;
        private readonly Dictionary<T, int> _itemLocation;

        public int Count
        {
            get { return _heap.Count; }
        }

        public MinHeap(Comparison<T> comparison)
        {
            _heap = new List<T>();
            _comparison = comparison;
            _itemLocation = new Dictionary<T, int>();
        }

        public void Add(T item)
        {
            AddItem(item);

            int i = _heap.Count - 1;

            while (i > 0)
            {
                int parent = (i - 1) / 2;

                if (parent < 0)
                {
                    parent = 0;
                }

                if (_comparison(_heap[parent], _heap[i]) <= 0)
                {
                    break;
                }

                SwapItems(i, parent);
                i = parent;
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

            T min = _heap[0];

            SwapItems(0, _heap.Count - 1);
            RemoveLastItem();

            Heapify(0);

            return min;
        }

        public void Reprioritize(T item)
        {
            if (_itemLocation.ContainsKey(item))
            {
                int index = _itemLocation[item];

                if (index >= 0)
                {
                    int parent = (index - 1) / 2;

                    if (parent < 0)
                    {
                        parent = 0;
                    }

                    Heapify(parent);
                }
            }
        }

        private void Heapify(int n)
        {
            int smallest = n;
            int l = 2 * n + 1;
            int r = 2 * n + 2;
            bool leftMatch = false, rightMatch = false;

            if (l < _heap.Count && (_comparison(_heap[l], _heap[smallest]) <= 0))
            {
                smallest = l;
                leftMatch = true;
            }

            if (r < _heap.Count && (_comparison(_heap[r], _heap[smallest]) <= 0))
            {
                smallest = r;
                rightMatch = true;
            }

            if (smallest != n)
            {
                if (leftMatch && rightMatch)
                {
                    smallest = _comparison(_heap[l], _heap[r]) < 0 ? l : r;
                }

                SwapItems(n, smallest);
                Heapify(smallest);
            }
        }

        private void AddItem(T item)
        {
            _heap.Add(item);
            _itemLocation.Add(item, _heap.Count - 1);
        }

        private void RemoveLastItem()
        {
            int index = _heap.Count - 1;
            T last = _heap[index];

            _itemLocation.Remove(last);
            _heap.RemoveAt(index);
        }

        private void SwapItems(int i, int j)
        {
            T temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;

            int tempIndex = _itemLocation[_heap[i]];
            _itemLocation[_heap[i]] = _itemLocation[_heap[j]];
            _itemLocation[_heap[j]] = tempIndex;
        }
    }
}

