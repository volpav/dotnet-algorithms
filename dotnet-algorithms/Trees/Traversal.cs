using System;

namespace Algorithms.Trees
{
    public static class TreeTraversal
    {
        public static void PreOrder<T>(BinaryTreeNode<T> tree, Action<BinaryTreeNode<T>> visitor)
        {
            if (tree != null)
            {
                visitor(tree);
                PreOrder(tree.Left, visitor);
                PreOrder(tree.Right, visitor);
            }
        }

        public static void InOrder<T>(BinaryTreeNode<T> tree, Action<BinaryTreeNode<T>> visitor)
        {
            if (tree != null)
            {
                InOrder(tree.Left, visitor);
                visitor(tree);
                InOrder(tree.Right, visitor);
            }
        }

        public static void PostOrder<T>(BinaryTreeNode<T> tree, Action<BinaryTreeNode<T>> visitor)
        {
            if (tree != null)
            {
                PostOrder(tree.Left, visitor);
                PostOrder(tree.Right, visitor);
                visitor(tree);
            }
        }
    }
}