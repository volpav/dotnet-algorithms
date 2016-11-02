using System;

namespace Algorithms.Search
{
    /// <summary>
    /// Contains search-related algorithms.
    /// </summary>
    public static class Search
    {
        /// <summary>
        /// Searches for a given item in a sorted set using binary search algorithm.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="items">Items set to examine.</param>
        /// <param name="item">Item to search for.</param>
        /// <returns>Zero-based index for an item, if found. Otherwise, -1.</returns>
        /// <exception cref="System.ArgumentNullException">Occurs when item set is null.</exception>
        /// <remarks>Alias: search/bc, binary-search</remarks>
        public static int BinarySearch<T>(T[] items, T item) where T: IComparable<T>
        {
            if (items == null) throw new ArgumentNullException("items");

            int len = items.Length;

            if (len == 0) return -1;
            else if (len == 1)
            {
                if (items[0].CompareTo(item) == 0) return 0;
                else return -1;
            }
            else
            {
                int mid = -1, start = 0, end = len - 1;

                do
                {
                    mid = (start + end + 1) / 2;

                    int comp = items[mid].CompareTo(item);

                    if (comp == 0) return mid;
                    else
                    {
                        if (comp < 0)
                        {
                            start = mid + 1;
                            
                        }
                        else
                        {
                            end = mid - 1;
                        }
                    }
                }
                while (start <= end);
            }

            return -1;
        } 
    }
}
