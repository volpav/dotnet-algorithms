using System;
using Xunit;

using Algorithms.Trees;

namespace Tests.Trees
{
    public class BinaryTreeTests : TestBase
    {
        [Fact]
        public void ShouldCorrectlyHandleNullArray()
        {
            BinaryTreeNode<int> tree = null;
            Exception error = null;

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
        public void ShouldCorrectlyHandleEmptyArray()
        {
            BinaryTreeNode<int> tree = null;
            Exception error = null;

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
        public void ShouldConstructTreeFromSingleElementArray()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(new int[] { 1 });
            
            Assert.True(tree != null);
            Assert.True(tree.Value == 1);
            Assert.True(tree.Left == null);
            Assert.True(tree.Right == null);
        }

        [Fact]
        public void ShouldConstructTreeFromTwoElementArray()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(new int[] { 1, 2 });
            
            Assert.True(tree != null);
            Assert.True(tree.Value == 1);
            Assert.True(tree.Left != null && tree.Left.Value == 2);
            Assert.True(tree.Left.Left == null && tree.Left.Right == null);
            Assert.True(tree.Right == null);
        }

        [Fact]
        public void ShouldConstructTreeFromTreeElementArray()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(new int[] { 1, 2, 3 });
            
            Assert.True(tree != null);
            Assert.True(tree.Value == 1);
            Assert.True(tree.Left != null && tree.Left.Value == 2);
            Assert.True(tree.Left.Left == null && tree.Left.Right == null);
            Assert.True(tree.Right != null && tree.Right.Value == 3);
            Assert.True(tree.Right.Left == null && tree.Right.Right == null);
        }

        [Fact]
        public void ShouldConstructTreeFromArbitraryArray()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(new int[] { 1, 5, 4, 2, -2, -1, 3, 8 });
            
            Assert.True(tree != null);

            Assert.True(tree.Value == 1);
            Assert.True(tree.Left.Value == 5);
            Assert.True(tree.Right.Value == 4);
            Assert.True(tree.Left.Left.Value == 2);
            Assert.True(tree.Left.Right.Value == -2);
            Assert.True(tree.Right.Left.Value == -1);
            Assert.True(tree.Right.Right.Value == 3);
            Assert.True(tree.Left.Left.Left.Value == 8);
        }
    }
}