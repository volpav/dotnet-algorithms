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

        [Fact]
        public void CanBFSAcyclicGraphAsAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(
                "7 6\n1 2\n1 3\n2 4\n2 5\n3 6\n3 7\n"
            ));

            var g = Graph.AsAdjacencyList(scanner, directed: false);
            var path = new List<int>();

            GraphTraversal.BFS(g, 0, (node) => path.Add(node));

            Assert.True(path.Count == 7);

            Assert.True(
                string.Join(",", path.Select(x => x.ToString())) ==
                "0,1,2,3,4,5,6"
            );
        }

        [Fact]
        public void CanBFSCyclicGraphAsAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(
                "3 3\n1 2\n1 3\n2 3"
            ));

            var g = Graph.AsAdjacencyList(scanner, directed: false);
            var path = new List<int>();

            GraphTraversal.BFS(g, 0, (node) => path.Add(node));

            Assert.True(path.Count == 3);

            Assert.True(
                string.Join(",", path.Select(x => x.ToString())) ==
                "0,1,2"
            );
        }

        [Fact]
        public void CanBFSAcyclicGraphWithBacktrackingAsAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(
                "7 6\n1 2\n1 3\n2 4\n2 5\n3 6\n3 7\n"
            ));

            var g = Graph.AsAdjacencyList(scanner, directed: false);
            var path = new List<Tuple<int, int>>();
            var explored = new List<Tuple<int, int>>();

            GraphTraversal.BFS(g, 0, 
                (node, parent) => path.Add(new Tuple<int, int>(node, parent)), 
                (node, parent) => explored.Add(new Tuple<int, int>(node, parent))
            );

            Assert.True(path.Count == 7);

            Assert.True(
                string.Join(",", path.Select(x => string.Format("({0},{1})", x.Item1, x.Item2))) ==
                "(0,0),(1,1),(2,1),(3,3),(4,3),(5,4),(6,5)"
            );

            Assert.True(explored.Count == 3);

            Assert.True(
                string.Join(",", explored.Select(x => string.Format("({0},{1})", x.Item1, x.Item2))) ==
                "(0,0),(2,2),(6,6)"
            );
        }

        [Fact]
        public void CanBFSAcyclicGraphAsVertexList()
        {
            var scanner = new Scanner(CreateStream(
                "7 6\n1 2\n1 3\n2 4\n2 5\n3 6\n3 7\n"
            ));

            var g = Graph.AsVertexList(scanner, directed: false);
            var path = new List<int>();

            GraphTraversal.BFS(g, g[0], (node) => path.Add(node.Index));

            Assert.True(path.Count == 7);

            Assert.True(
                string.Join(",", path.Select(x => x.ToString())) ==
                "0,1,2,3,4,5,6"
            );
        }

        [Fact]
        public void CanBFSCyclicGraphAsVertexList()
        {
            var scanner = new Scanner(CreateStream(
                "3 3\n1 2\n1 3\n2 3"
            ));

            var g = Graph.AsVertexList(scanner, directed: false);
            var path = new List<int>();

            GraphTraversal.BFS(g, g[0], (node) => path.Add(node.Index));

            Assert.True(path.Count == 3);

            Assert.True(
                string.Join(",", path.Select(x => x.ToString())) ==
                "0,1,2"
            );
        }

        [Fact]
        public void CanBFSAcyclicGraphWithBacktrackingAsVertexList()
        {
            var scanner = new Scanner(CreateStream(
                "7 6\n1 2\n1 3\n2 4\n2 5\n3 6\n3 7\n"
            ));

            var g = Graph.AsVertexList(scanner, directed: false);
            var path = new List<Tuple<int, int>>();
            var explored = new List<Tuple<int, int>>();

            GraphTraversal.BFS(g, g[0], 
                (node, parent) => path.Add(new Tuple<int, int>(node.Index, parent.Index)), 
                (node, parent) => explored.Add(new Tuple<int, int>(node.Index, parent.Index))
            );

            Assert.True(path.Count == 7);

            Assert.True(
                string.Join(",", path.Select(x => string.Format("({0},{1})", x.Item1, x.Item2))) ==
                "(0,0),(1,1),(2,1),(3,3),(4,3),(5,4),(6,5)"
            );

            Assert.True(explored.Count == 3);

            Assert.True(
                string.Join(",", explored.Select(x => string.Format("({0},{1})", x.Item1, x.Item2))) ==
                "(0,0),(2,2),(6,6)"
            );
        }

        [Fact]
        public void CanComputeMinPathWithDijkstraAsAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(
                "8 9\n1 2\n1 3\n2 4\n2 5\n3 6\n3 7\n1 6\n5 8\n6 8"
            ));

            var g = Graph.AsAdjacencyList(scanner, directed: false);

            var weights = Graph.ConstantWeights(g.Length, 1, g);

            var minPath = GraphTraversal.Dijkstra(g, weights, 0);

            Assert.True(minPath.Item1.Length == g.Length);
            Assert.True(minPath.Item2.Length <= g.Length);

            Assert.True(minPath.Item1[0] == 0);
            Assert.True(minPath.Item1[1] == 1);
            Assert.True(minPath.Item1[2] == 1);
            Assert.True(minPath.Item1[3] == 2);
            Assert.True(minPath.Item1[4] == 2);
            Assert.True(minPath.Item1[5] == 1);
            Assert.True(minPath.Item1[6] == 2);
            Assert.True(minPath.Item1[7] == 2);
        }

        [Fact]
        public void CanComputeMinPathWithDijkstraAsVertexList()
        {
            var scanner = new Scanner(CreateStream(
                "8 9\n1 2\n1 3\n2 4\n2 5\n3 6\n3 7\n1 6\n5 8\n6 8"
            ));

            var g = Graph.AsVertexList(scanner, directed: false);
            g = Graph.ConstantWeights(g, 1);

            var minPath = GraphTraversal.Dijkstra(g, g[0]);

            Assert.True(minPath.Item1.Length == g.Length);
            Assert.True(minPath.Item2.Length <= g.Length);

            Assert.True(minPath.Item1[0] == 0);
            Assert.True(minPath.Item1[1] == 1);
            Assert.True(minPath.Item1[2] == 1);
            Assert.True(minPath.Item1[3] == 2);
            Assert.True(minPath.Item1[4] == 2);
            Assert.True(minPath.Item1[5] == 1);
            Assert.True(minPath.Item1[6] == 2);
            Assert.True(minPath.Item1[7] == 2);
        }

        [Fact]
        public void CanComputeMSTAsAdjacencyList()
        {
            var scanner = new Scanner(CreateStream(
                "5 10\n1 2 24\n1 3 13\n1 4 13\n1 5 22\n2 3 22\n2 4 13\n2 5 13\n3 4 19\n3 5 14\n4 5 19"
            ));

            var weights = new int[5, 5];
            var g = Graph.AsAdjacencyList(scanner, out weights, directed: false, weighted: true);

            var mst = GraphTraversal.MST(g, weights, 0);

            Assert.True(mst.Item1.Length == g.Length);
            Assert.True(mst.Item2 == 52);

            Assert.True(mst.Item1[0] == 0);
            Assert.True(mst.Item1[1] == 2);
            Assert.True(mst.Item1[2] == 3);
            Assert.True(mst.Item1[3] == 1);
            Assert.True(mst.Item1[4] == 4);
        }

        [Fact]
        public void CanComputeMSTAsVertexList()
        {
            var scanner = new Scanner(CreateStream(
                "5 10\n1 2 24\n1 3 13\n1 4 13\n1 5 22\n2 3 22\n2 4 13\n2 5 13\n3 4 19\n3 5 14\n4 5 19"
            ));

            var g = Graph.AsVertexList(scanner, directed: false, weighted: true);

            var mst = GraphTraversal.MST(g, g[0]);

            Assert.True(mst.Item1.Length == g.Length);
            Assert.True(mst.Item2 == 52);

            Assert.True(mst.Item1[0] == 0);
            Assert.True(mst.Item1[1] == 2);
            Assert.True(mst.Item1[2] == 3);
            Assert.True(mst.Item1[3] == 1);
            Assert.True(mst.Item1[4] == 4);
        }
    }
}