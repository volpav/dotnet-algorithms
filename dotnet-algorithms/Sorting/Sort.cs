using System;

namespace Algorithms.Sorting
{
    /// <summary>
    /// Contains sort-related algorithms.
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// Sorts the given array in place using quick sort algorithm.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="items">Items to sort.</param>
        /// <exception cref="System.ArgumentNullException">Occurs when items array is null.</exception>
        /// <remarks>Alias: sorting/qs, quick-sort</remarks>
        public static void QuickSort<T>(T[] items) where T: IComparable<T>
        {
            if (items == null) throw new ArgumentNullException("items");

            QuickSort(items, 0, items.Length - 1);
        }

        /// <summary>
        /// Sorts the given array in place.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="items">Items to sort.</param>
        /// <param name="low">Start index.</param>
        /// <param name="high">End index.</param>
        private static void QuickSort<T>(T[] items, int low, int high)  where T: IComparable<T>
        {
            if (low < high)
            {
                int pivot = Partition(items, low, high);
                QuickSort(items, low, pivot - 1);
                QuickSort(items, pivot + 1, high);
            }
        }

        /// <summary>
        /// Rearranges items in a sorted order and returns partition end index.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="items">Items to rearrange.</param>
        /// <param name="low">Start index.</param>
        /// <param name="high">End index.</param>
        private static int Partition<T>(T[] items, int low, int high)  where T: IComparable<T>
        {
            T pivot = items[high];
            int ret = low;

            for (int i = low; i <= high; i++)
            {
                if (items[i].CompareTo(pivot) < 0)
                {
                    Swap(items, i, ret);
                    ret++;
                }
            }

            Swap(items, ret, high);

            return ret;
        }

        /// <summary>
        /// Swaps two elements in the given array.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="items">Items array.</param>
        /// <param name="i">Index of a first element.</param>
        /// <param name="j">Index of a second element.</param>
        private static void Swap<T>(T[] items, int i, int j) 
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        /// <summary>
        /// Sorts the given array in place using merge sort algorithm.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="items">Items to sort.</param>
        /// <exception cref="System.ArgumentNullException">Occurs when items array is null.</exception>
        /// <remarks>Alias: sorting/ms, merge-sort</remarks>
        public static void MergeSort<T>(T[] items) where T: IComparable<T>
        {
            if (items == null) throw new ArgumentNullException("items");

            MergeSort(items, (T[])Array.CreateInstance(typeof(T), items.Length), 0, items.Length);
        }

        /// <summary>
        /// Sorts the given array in place using "divide and conquer" approach.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="items">Items to sort.</param>
        /// <param name="temp">Temporary buffer.</param>
        /// <param name="low">Start index.</param>
        /// <param name="high">End index.</param>
        private static void MergeSort<T>(T[] items, T[] temp, int low, int high) where T: IComparable<T>
        {
            if (high - low > 1)
            {
                int middle = (low + high) / 2;

                MergeSort(items, temp, low, middle);
                MergeSort(items, temp, middle, high);
                Merge(items, temp, low, middle, high);
                Copy(temp, items, low, high);
            }
        }

        /// <summary>
        /// Merges the two arrays.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="items">Items to sort.</param>
        /// <param name="temp">Temporary buffer.</param>
        /// <param name="low">Start index.</param>
        /// <param name="middle">Middle index.</param>
        /// <param name="high">End index.</param>
        private static void Merge<T>(T[] items, T[] temp, int low, int middle, int high) where T: IComparable<T>
        {
            int i = low, j = middle;

            for (int k = low; k < high; k++)
            {
                if (i < middle && (j >= high || items[i].CompareTo(items[j]) <= 0))
                {
                    temp[k] = items[i];
                    i++;
                }
                else
                {
                    temp[k] = items[j];
                    j++;
                }
            }
        }

        /// <summary>
        /// Copies all items from one array into another.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="source">Source array.</param>
        /// <param name="target">Target array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="end">End index.</param>
        private static void Copy<T>(T[] source, T[] target, int start, int end)
        {
            for (var i = start; i < end; i++) 
            {
                target[i] = source[i];
            }
        }
    }
}