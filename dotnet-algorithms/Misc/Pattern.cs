using System;

namespace Algorithms.Misc
{
    public static class Pattern
    {
        public static int LongestIncreasingSubsequenceLength<T>(T[] items) where T: IComparable<T>
        {
            int ret = 0;

            if (items != null && items.Length > 0)
            {
                int[] L = new int[items.Length];

                ret = 1;

                for (int i = 1; i < items.Length; i++)
                {
                    L[i] = items[i].CompareTo(items[i - 1]) > 0 ? L[i - 1] + 1 : 1;
                    
                    if (L[i] > ret) 
                    {
                        ret = L[i];
                    }
                }
            }

            return ret;
        }
    }
}