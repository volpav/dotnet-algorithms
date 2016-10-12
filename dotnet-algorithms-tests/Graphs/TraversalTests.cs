using System;
using System.Linq;
using System.Collections.Generic;

using Xunit;

using Algorithms.IO;
using Algorithms.Graphs;

namespace Tests.Graphs
{
    public class TraversalTests : TestBase
    {
        [Fact]
        public void CanDFSAcyclicGraphAsAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(
                "7 6\n1 2\n1 3\n2 4\n2 5\n3 6\n3 7\n"
            ));

            var g = Graph.AsAdjacencyList(scanner, directed: false);
            var path = new List<int>();

            GraphTraversal.DFS(g, 0, (node) => path.Add(node));

            Assert.True(path.Count == 7);

            Assert.True(
                string.Join(",", path.Select(x => x.ToString())) ==
                "0,2,6,5,1,4,3"
            );
        }

        [Fact]
        public void CanDFSCyclicGraphAsAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(
                "3 3\n1 2\n1 3\n2 3"
            ));

            var g = Graph.AsAdjacencyList(scanner, directed: false);
            var path = new List<int>();

            GraphTraversal.DFS(g, 0, (node) => path.Add(node));

            Assert.True(path.Count == 3);

            Assert.True(
                string.Join(",", path.Select(x => x.ToString())) ==
                "0,2,1"
            );
        }

        [Fact]
        public void CanDFSAcyclicGraphWithBacktrackingAsAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(
                "7 6\n1 2\n1 3\n2 4\n2 5\n3 6\n3 7\n"
            ));

            var g = Graph.AsAdjacencyList(scanner, directed: false);
            var path = new List<Tuple<int, int>>();
            var explored = new List<Tuple<int, int>>();

            GraphTraversal.DFS(g, 0, 
                (node, parent) => path.Add(new Tuple<int, int>(node, parent)), 
                (node, parent) => explored.Add(new Tuple<int, int>(node, parent))
            );

            Assert.True(path.Count == 7);

            Assert.True(
                string.Join(",", path.Select(x => string.Format("({0},{1})", x.Item1, x.Item2))) ==
                "(0,0),(1,0),(3,1),(4,1),(2,0),(5,2),(6,2)"
            );

            Assert.True(explored.Count == 7);

            Assert.True(
                string.Join(",", explored.Select(x => string.Format("({0},{1})", x.Item1, x.Item2))) ==
                "(3,1),(4,1),(1,0),(5,2),(6,2),(2,0),(0,0)"
            );
        }

        [Fact]
        public void CanDFSAcyclicGraphAsVertexList()
        {
            var scanner = new Scanner(CreateStream(
                "7 6\n1 2\n1 3\n2 4\n2 5\n3 6\n3 7\n"
            ));

            var g = Graph.AsVertexList(scanner, directed: false);
            var path = new List<int>();

            GraphTraversal.DFS(g, g[0], (node) => path.Add(node.Index));

            Assert.True(path.Count == 7);

            Assert.True(
                string.Join(",", path.Select(x => x.ToString())) ==
                "0,2,6,5,1,4,3"
            );
        }

        [Fact]
        public void CanDFSCyclicGraphAsVertexList()
        {
            var scanner = new Scanner(CreateStream(
                "3 3\n1 2\n1 3\n2 3"
            ));

            var g = Graph.AsVertexList(scanner, directed: false);
            var path = new List<int>();

            GraphTraversal.DFS(g, g[0], (node) => path.Add(node.Index));

            Assert.True(path.Count == 3);

            Assert.True(
                string.Join(",", path.Select(x => x.ToString())) ==
                "0,2,1"
            );
        }

        [Fact]
        public void CanDFSAcyclicGraphWithBacktrackingAsVertexList()
        {
            var scanner = new Scanner(CreateStream(
                "7 6\n1 2\n1 3\n2 4\n2 5\n3 6\n3 7\n"
            ));

            var g = Graph.AsVertexList(scanner, directed: false);
            var path = new List<Tuple<int, int>>();
            var explored = new List<Tuple<int, int>>();

            GraphTraversal.DFS(g, g[0], 
                (node, parent) => path.Add(new Tuple<int, int>(node.Index, parent.Index)), 
                (node, parent) => explored.Add(new Tuple<int, int>(node.Index, parent.Index))
            );

            Assert.True(path.Count == 7);

            Assert.True(
                string.Join(",", path.Select(x => string.Format("({0},{1})", x.Item1, x.Item2))) ==
                "(0,0),(1,0),(3,1),(4,1),(2,0),(5,2),(6,2)"
            );

            Assert.True(explored.Count == 7);

            Assert.True(
                string.Join(",", explored.Select(x => string.Format("({0},{1})", x.Item1, x.Item2))) ==
                "(3,1),(4,1),(1,0),(5,2),(6,2),(2,0),(0,0)"
            );
        }
    }
}