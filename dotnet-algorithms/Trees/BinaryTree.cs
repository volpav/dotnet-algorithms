using System.Collections.Generic;

namespace Algorithms.Trees
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }       
    }

    public static class BinaryTree
    {
        public static BinaryTreeNode<T> FromArray<T>(T[] values)
        {
            if (values == null || values.Length == 0)
            {
                return null;
            }

            var nodes = new List<BinaryTreeNode<T>>();
            nodes.Add(new BinaryTreeNode<T>() { Value = values[0] });

            for (int i = 0; i < values.Length; i++)
            {
                int left = 2 * i + 1,
                    right = 2 * i + 2;

                var cur = nodes[i];

                if (left < values.Length)
                {
                    var leftNode = new BinaryTreeNode<T>() { Value = values[left] };
                    
                    nodes.Add(leftNode);
                    cur.Left = leftNode;
                }

                if (right < values.Length)
                {
                    var rightNode = new BinaryTreeNode<T>() { Value = values[right] };
                    
                    nodes.Add(rightNode);
                    cur.Right = rightNode;
                }
            }

            return nodes[0];
        }
    }
}