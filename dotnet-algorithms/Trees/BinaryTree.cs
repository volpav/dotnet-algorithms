using System.Collections.Generic;

namespace Algorithms.Trees 
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode() : this(default(T)) { }
        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }
    }

    public static class BinaryTree 
    {
        public static BinaryTreeNode<T> FromArray<T>(T[] values)
        {
            if (values == null || values.Length == 0)
            {
                return null;
            }

            var nodes = new List<BinaryTreeNode<T>>()
            {
                new BinaryTreeNode<T>(values[0])
            };

            for (int i = 0; i < values.Length; i++)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                var current = nodes[i];

                if (left < values.Length)
                {
                    current.Left = new BinaryTreeNode<T>(values[left]);
                    nodes.Add(current.Left);
                }

                if (right < values.Length)
                {
                    current.Right = new BinaryTreeNode<T>(values[right]);
                    nodes.Add(current.Right);
                }
            }

            return nodes[0];
        }
    }
}