using System;

namespace Algorithms.Sorting
{
    public static class Sort
    {
        public static void QuickSort<T>(T[] items) where T: IComparable<T>
        {
            if (items == null) 
            {
                throw new ArgumentNullException("items");
            }

            QuickSort(items, 0, items.Length - 1);
        }

        private static void QuickSort<T>(T[] items, int low, int high)  where T: IComparable<T>
        {
            if (low < high)
            {
                int pivot = Partition(items, low, high);
                QuickSort(items, low, pivot - 1);
                QuickSort(items, pivot + 1, high);
            }
        }

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

        private static void Swap<T>(T[] items, int i, int j) 
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        public static void MergeSort<T>(T[] items) where T: IComparable<T>
        {
            if (items == null) 
            {
                throw new ArgumentNullException("items");
            }

            MergeSort(items, (T[])Array.CreateInstance(typeof(T), items.Length), 0, items.Length);
        }

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

        private static void Copy<T>(T[] source, T[] target, int start, int end)
        {
            for (int i = start; i < end; i++) 
            {
                target[i] = source[i];
            }
        }
    }
}