using System;
using System.Linq;
using Xunit;

using Algorithms.IO;
using Algorithms.Graphs;

namespace Tests.Graphs
{
    public class GraphTests : TestBase
    {
        private readonly int graphVertexCount = 3;
        private readonly string unweightedGraphInput = "3 3\n1 2\n1 3\n2 3";
        private readonly string weightedGraphInput = "3 3\n1 2 3\n1 3 4\n2 3 5";

        [Fact]
        public void CanReturnUndirectedUnweightedAdjacencyMatrix()
        {
            var scanner = new Scanner(CreateStream(unweightedGraphInput));

            var g = Graph.AsAdjacencyMatrix(scanner);

            for (var i = 0; i < graphVertexCount; i++)
            {
                for (var j = 0; j < graphVertexCount; j++)
                {
                    if (i != j)
                    {
                        Assert.True(g[i, j] == 1);
                    }
                }
            }
        }

        [Fact]
        public void CanReturnUndirectedWeightedAdjacencyMatrix()
        {
            var scanner = new Scanner(CreateStream(weightedGraphInput));

            var g = Graph.AsAdjacencyMatrix(scanner, directed: false, weighted: true);

            for (var i = 0; i < graphVertexCount; i++)
            {
                for (var j = 0; j < graphVertexCount; j++)
                {
                    if (i != j)
                    {
                        Assert.True(g[i, j] == (i + 1) + (j + 1));
                    }
                }
            }
        }

        [Fact]
        public void CanReturnDirectedWeightedAdjacencyMatrix()
        {
            var scanner = new Scanner(CreateStream(weightedGraphInput));

            var g = Graph.AsAdjacencyMatrix(scanner, directed: true, weighted: true);

            Assert.True(g[0, 0] == 0);
            Assert.True(g[0, 1] == 3);
            Assert.True(g[0, 2] == 4);
            Assert.True(g[1, 0] == 0);
            Assert.True(g[1, 1] == 0);
            Assert.True(g[1, 2] == 5);
            Assert.True(g[2, 0] == 0);
            Assert.True(g[2, 1] == 0);
            Assert.True(g[2, 2] == 0);
        }

        [Fact]
        public void CanReturnUndirectedUnweightedAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(unweightedGraphInput));

            var g = Graph.AsAdjacencyList(scanner, directed: false);

            Assert.True(g.Length == graphVertexCount);
            
            for (var i = 0; i < g.Length; i++)
            {
                var adj = g[i];

                Assert.True(adj.Length == graphVertexCount - 1);

                var edges = Enumerable.Range(0, graphVertexCount)
                    .Where(x => Array.IndexOf(adj, x) >= 0)
                    .Count();
                
                Assert.True(edges == graphVertexCount - 1);
                Assert.True(Array.IndexOf(adj, i) < 0);
            }
        }

        [Fact]
        public void CanReturnUndirectedWeightedAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(weightedGraphInput));

            var weights = new int[graphVertexCount, graphVertexCount];
            var g = Graph.AsAdjacencyList(scanner, out weights, directed: false, weighted: true);

            Assert.True(g.Length == graphVertexCount);
            
            for (var i = 0; i < g.Length; i++)
            {
                var adj = g[i];

                Assert.True(adj.Length == graphVertexCount - 1);

                var edges = Enumerable.Range(0, graphVertexCount)
                    .Where(x => Array.IndexOf(adj, x) >= 0)
                    .Count();
                
                Assert.True(edges == graphVertexCount - 1);
                Assert.True(Array.IndexOf(adj, i) < 0);
            }

            Assert.True(weights[0, 0] == 0);
            Assert.True(weights[0, 1] == 3);
            Assert.True(weights[0, 2] == 4);
            Assert.True(weights[1, 0] == 3);
            Assert.True(weights[1, 1] == 0);
            Assert.True(weights[1, 2] == 5);
            Assert.True(weights[2, 0] == 4);
            Assert.True(weights[2, 1] == 5);
            Assert.True(weights[2, 2] == 0);
        }

        [Fact]
        public void CanReturnDirectedWeightedAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(weightedGraphInput));

            var weights = new int[graphVertexCount, graphVertexCount];
            var g = Graph.AsAdjacencyList(scanner, out weights, directed: true, weighted: true);

            Assert.True(g.Length == graphVertexCount);
            
            Assert.True(g[0].Length == 2);
            Assert.True(g[1].Length == 1);
            Assert.True(g[2].Length == 0);

            Assert.True(new int[] { 1, 2 }.All(x => Array.IndexOf(g[0], x) >= 0));
            Assert.True(new int[] { 2 }.All(x => Array.IndexOf(g[1], x) >= 0));

            Assert.True(weights[0, 0] == 0);
            Assert.True(weights[0, 1] == 3);
            Assert.True(weights[0, 2] == 4);
            Assert.True(weights[1, 0] == 0);
            Assert.True(weights[1, 1] == 0);
            Assert.True(weights[1, 2] == 5);
            Assert.True(weights[2, 0] == 0);
            Assert.True(weights[2, 1] == 0);
            Assert.True(weights[2, 2] == 0);
        }

        [Fact]
        public void CanReturnUndirectedUnweightedVertexList()
        {
            var scanner = new Scanner(CreateStream(unweightedGraphInput));

            var g = Graph.AsVertexList(scanner, directed: false, weighted: false);

            Assert.True(g.Length == graphVertexCount);
            
            for (var i = 0; i < g.Length; i++)
            {
                var n = g[i];

                Assert.True(n.Edges.Count == graphVertexCount - 1);
                Assert.True(n.Edges.All(e => e.Weight == null));
            }

            Assert.True(g[0].Edges[0].FromVertex == g[0]);
            Assert.True(g[0].Edges[0].ToVertex == g[1]);
            Assert.True(g[0].Edges[1].FromVertex == g[0]);
            Assert.True(g[0].Edges[1].ToVertex == g[2]);
            Assert.True(g[1].Edges[0].FromVertex == g[1]);
            Assert.True(g[1].Edges[0].ToVertex == g[0]);
            Assert.True(g[2].Edges[0].FromVertex == g[2]);
            Assert.True(g[2].Edges[0].ToVertex == g[0]);
            Assert.True(g[1].Edges[1].FromVertex == g[1]);
            Assert.True(g[1].Edges[1].ToVertex == g[2]);
            Assert.True(g[2].Edges[1].FromVertex == g[2]);
            Assert.True(g[2].Edges[1].ToVertex == g[1]);
        }

        [Fact]
        public void CanReturnDirectedWeightedVertexList()
        {
            var scanner = new Scanner(CreateStream(weightedGraphInput));

            var g = Graph.AsVertexList(scanner, directed: true, weighted: true);

            Assert.True(g.Length == graphVertexCount);
            
            Assert.True(g[0].Edges[0].FromVertex == g[0]);
            Assert.True(g[0].Edges[0].ToVertex == g[1]);
            Assert.True(g[0].Edges[0].Weight == 3);
            Assert.True(g[0].Edges[1].FromVertex == g[0]);
            Assert.True(g[0].Edges[1].ToVertex == g[2]);
            Assert.True(g[0].Edges[1].Weight == 4);
            Assert.True(g[1].Edges[0].FromVertex == g[1]);
            Assert.True(g[1].Edges[0].ToVertex == g[2]);
            Assert.True(g[1].Edges[0].Weight == 5);
        }
    }
}