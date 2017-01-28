using Xunit;

using Algorithms.Trees;

namespace Tests.Trees
{
    public class TreeTraversalTests : TestBase
    {
        private static int[] arbTree = new int[] { 1, 5, 4, 2, -2, -1, 3, 8 };

        [Fact]
        public void ShouldCorrectlyTraverseUsingPreOrder()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(arbTree);

            int[] expected = new int[] { 1, 5, 2, 8, -2, 4, -1, 3 };
            int[] actual = new int[arbTree.Length];
            int i = 0;

            TreeTraversal.PreOrder(tree, n => 
            {
                actual[i++] = n.Value;
            });

            for (i = 0; i < expected.Length; i++)
            {
                Assert.True(expected[i] == actual[i]);
            }
        }

        [Fact]
        public void ShouldCorrectlyTraverseUsingInOrder()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(arbTree);

            int[] expected = new int[] { 8, 2, 5, -2, 1, -1, 4, 3 };
            int[] actual = new int[arbTree.Length];
            int i = 0;

            TreeTraversal.InOrder(tree, n => 
            {
                actual[i++] = n.Value;
            });

            for (i = 0; i < expected.Length; i++)
            {
                Assert.True(expected[i] == actual[i]);
            }
        }

        [Fact]
        public void ShouldCorrectlyTraverseUsingPostOrder()
        {
            BinaryTreeNode<int> tree = BinaryTree.FromArray(arbTree);

            int[] expected = new int[] { 8, 2, -2, 5, -1, 3, 4, 1 };
            int[] actual = new int[arbTree.Length];
            int i = 0;

            TreeTraversal.PostOrder(tree, n => 
            {
                actual[i++] = n.Value;
            });

            for (i = 0; i < expected.Length; i++)
            {
                Assert.True(expected[i] == actual[i]);
            }
        }
    }
}