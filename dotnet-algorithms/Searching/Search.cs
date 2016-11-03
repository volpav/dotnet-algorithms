using System;

namespace Algorithms.Searching
{
    public static class Search
    {
        public static int BinarySearch<T>(T[] items, T item) where T: IComparable<T>
        {
            if (items == null) 
            {
                throw new ArgumentNullException("items");
            }

            int len = items.Length;

            if (len == 0) 
            {
                return -1;
            }
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
