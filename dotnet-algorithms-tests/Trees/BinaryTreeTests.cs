using System;
using Xunit;

using Algorithms.Trees;

namespace Tests.Trees
{
    public class BinaryTreeTests : TestBase
    {
        [Fact]
        public void CreateShouldHandleNullArray()
        {
            Exception error = null;
            BinaryTreeNode<int> tree = null;

            try 
            {
                tree = BinaryTree.FromArray<int>(null);
            }
            catch (Exception ex)
            {
                error = ex;
            }

            Assert.True(error == null);
            Assert.True(tree == null);
        }

        [Fact]
        public void CreateShouldHandleEmptyArray()
        {
Exception error = null;
            BinaryTreeNode<int> tree = null;

            try 
            {
                tree = BinaryTree.FromArray(new int[] { });
            }
            catch (Exception ex)
            {
                error = ex;
            }

            Assert.True(error == null);
            Assert.True(tree == null);
        }

        [Fact]
        public void CreateShouldProcessSingleElementArray()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(new int[] { 1 });

            Assert.True(tree != null);
            Assert.True(tree.Value == 1);
            Assert.True(tree.Left == null);
            Assert.True(tree.Right == null);
        }

        [Fact]
        public void CreateShouldProcessArrayWithTwoElements()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(new int[] { 1, 2 });

            Assert.True(tree != null && tree.Value == 1);
            Assert.True(tree.Left != null && tree.Left.Value == 2);
            Assert.True(tree.Right == null);
        }

        [Fact]
        public void CreateShouldProcessArrayWithTreeElements()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(new int[] { 1, 2, 3 });

            Assert.True(tree != null && tree.Value == 1);
            Assert.True(tree.Left != null && tree.Left.Value == 2);
            Assert.True(tree.Right != null && tree.Right.Value == 3);
        }

        [Fact]
        public void CreateShouldProcessArbitraryArray()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(new int[] { 1, 5, 4, 2, -2, -1, 3, 8 });

            Assert.True(tree != null && tree.Value == 1);
            Assert.True(tree.Left != null && tree.Left.Value == 5);
            Assert.True(tree.Right != null && tree.Right.Value == 4);
            Assert.True(tree.Left.Left != null && tree.Left.Left.Value == 2);
            Assert.True(tree.Left.Right != null && tree.Left.Right.Value == -2);
            Assert.True(tree.Right.Left != null && tree.Right.Left.Value == -1);
            Assert.True(tree.Right.Right != null && tree.Right.Right.Value == 3);
            Assert.True(tree.Left.Left.Left != null && tree.Left.Left.Left.Value == 8);
        }
    }
}