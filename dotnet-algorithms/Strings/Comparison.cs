namespace Algorithms.Strings
{
    /// <summary>
    /// Contains comparison-related string algorithms.
    /// </summary>
    public static class StringComparison
    {
        /// <summary>
        /// Calculates edit distance (no classification of operations) between the two given strings.
        /// </summary>
        /// <param name="str1">First string.</param>
        /// <param name="str2">Second string.</param>
        /// <remarks>Alias: strings/comparison/ed, edit-distance</remarks>
        public static int EditDistance(string str1, string str2)
        {
            if (str1 == null)
            {
                if (str2 == null) return 0;
                else return str2.Length;
            }
            else if (str2 == null)
            {
                if (str1 == null) return 0;
                else return str1.Length;
            }

            char[] a = str1.ToCharArray(), b = str2.ToCharArray();

            int[,] D = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++) D[i, 0] = i;
            for (int i = 0; i <= b.Length; i++) D[0, i] = i;

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    int left = D[i, j - 1];
                    int top = D[i - 1, j];
                    int topLeft = D[i - 1, j - 1];

                    int cur = System.Math.Min(System.Math.Min(left, top), topLeft);

                    if (a[i - 1] != b[j - 1]) cur++;
                    else cur = topLeft;

                    D[i, j] = cur;
                }
            }

            return D[a.Length, b.Length]; 
        }
    }
}