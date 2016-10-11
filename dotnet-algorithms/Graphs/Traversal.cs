using System;
using System.Collections.Generic;

namespace Algorithms.Graphs
{
    /// <summary>
    /// Contains graph traversal algorithms.
    /// </summary>
    public static class GraphTraversal
    {
        /// <summary>
        /// Executes a depth-first traversal of a given graph.
        /// </summary>
        /// <param name="adjacencyMatrix">Adjacency matrix.</param>
        /// <param name="start">Starting vertex.</param>
        /// <param name="visitor">Vertex visitor.</param>
        public static void DFS(int[][] adjacencyMatrix, int start, Action<int> visitor)
        {
            var s = new Stack<int>();
            var discoveredVertexIndicies = new HashSet<int>();

            s.Push(start);

            while (s.Count > 0)
            {
                var current = s.Pop();
                
                if (!discoveredVertexIndicies.Contains(current))
                {
                    discoveredVertexIndicies.Add(current);

                    visitor(current);

                    var edges = adjacencyMatrix[current];
                    var totalEdges = edges.Length;

                    for (var i = 0; i < totalEdges; i++)
                    {
                        s.Push(edges[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Executes a depth-first traversal of a given graph.
        /// </summary>
        /// <param name="vertices">Graph vertices.</param>
        /// <param name="start">Starting vertex.</param>
        /// <param name="visitor">Vertex visitor.</param>
        public static void DFS(Vertex[] vertices, Vertex start, Action<Vertex> visitor)
        {
            var s = new Stack<Vertex>();
            var discoveredVertexIndicies = new HashSet<int>();

            s.Push(start);

            while (s.Count > 0)
            {
                var current = s.Pop();
                var index = current.Index;

                if (!discoveredVertexIndicies.Contains(index))
                {
                    discoveredVertexIndicies.Add(index);

                    visitor(current);

                    var edges = current.Edges;
                    var totalEdges = edges.Count;

                    for (var i = 0; i < totalEdges; i++)
                    {
                        s.Push(edges[i].ToVertex);
                    }
                }
            }
        }

        /// <summary>
        /// Executes a recursive depth-first traversal of a given graph.
        /// </summary>
        /// <param name="vertices">Vertices.</param>
        /// <param name="start">Starting vertex.</param>
        /// <param name="discoveredVisitor">Vertex visitor, once discovered (arguments are current vertex as well as vertex of origin).</param>
        /// <param name="exploredVisitor">Vertex visitor, once fully explored (arguments are current vertex as well as vertex of origin).</param>
        public static void DFS(Vertex[] vertices, Vertex start, Action<Vertex, Vertex> discoveredVisitor, Action<Vertex, Vertex> exploredVisitor = null)
        {
            DFS(vertices, start.Index, start.Index, new HashSet<int>(), discoveredVisitor, exploredVisitor);
        }

        /// <summary>
        /// Executes a recursive depth-first traversal of a given graph.
        /// </summary>
        /// <param name="adjacencyMatrix">Adjacency matrix.</param>
        /// <param name="start">Starting vertex.</param>
        /// <param name="discoveredVisitor">Vertex visitor, once discovered (arguments are current vertex as well as vertex of origin).</param>
        /// <param name="exploredVisitor">Vertex visitor, once fully explored (arguments are current vertex as well as vertex of origin).</param>
        public static void DFS(int[][] adjacencyMatrix, int start, Action<int, int> discoveredVisitor, Action<int, int> exploredVisitor = null)
        {
            DFS(adjacencyMatrix, start, start, new HashSet<int>(), discoveredVisitor, exploredVisitor);
        }

        /// <summary>
        /// Executes a recursive depth-first traversal of a given graph.
        /// </summary>
        /// <param name="vertices">Vertices.</param>
        /// <param name="current">Current vertex index.</param>
        /// <param name="cameFrom">Vertex index of the vertex coming from.</param>
        /// <param name="discoveredVertexIndicies">A set of all the discovered vertices.</param>
        /// <param name="discoveredVisitor">Vertex visitor, once discovered (arguments are current vertex as well as vertex of origin).</param>
        /// <param name="exploredVisitor">Vertex visitor, once fully explored (arguments are current vertex as well as vertex of origin).</param>
        private static void DFS(
            Vertex[] vertices,
            int current,
            int cameFrom,
            HashSet<int> discoveredVertexIndicies,
            Action<Vertex, Vertex> discoveredVisitor,
            Action<Vertex, Vertex> exploredVisitor = null)
        {
            if (!discoveredVertexIndicies.Contains(current))
            {
                discoveredVertexIndicies.Add(current);

                discoveredVisitor(vertices[current], vertices[cameFrom]);

                var edges = vertices[current].Edges;
                var totalEdges = edges.Count;

                for (var i = 0; i < totalEdges; i++)
                {
                    DFS(
                        vertices,
                        edges[i].ToVertex.Index,
                        current,
                        discoveredVertexIndicies,
                        discoveredVisitor,
                        exploredVisitor
                    );
                }

                exploredVisitor?.Invoke(vertices[current], vertices[cameFrom]);
            }
        }

        /// <summary>
        /// Executes a recursive depth-first traversal of a given graph.
        /// </summary>
        /// <param name="adjacencyMatrix">Adjacency matrix.</param>
        /// <param name="current">Current vertex.</param>
        /// <param name="cameFrom">Vertex coming from.</param>
        /// <param name="discoveredVertexIndicies">A set of all the discovered vertices.</param>
        /// <param name="discoveredVisitor">Vertex visitor, once discovered (arguments are current vertex as well as vertex of origin).</param>
        /// <param name="exploredVisitor">Vertex visitor, once fully explored (arguments are current vertex as well as vertex of origin).</param>
        private static void DFS(
            int[][] adjacencyMatrix, 
            int current,
            int cameFrom,
            HashSet<int> discoveredVertexIndicies,
            Action<int, int> discoveredVisitor, 
            Action<int, int> exploredVisitor = null)
        {
            if (!discoveredVertexIndicies.Contains(current))
            {
                discoveredVertexIndicies.Add(current);

                discoveredVisitor(current, cameFrom);

                var edges = adjacencyMatrix[current];
                var totalEdges = edges.Length;

                for (var i = 0; i < totalEdges; i++)
                {
                    DFS(
                        adjacencyMatrix, 
                        edges[i], 
                        current, 
                        discoveredVertexIndicies, 
                        discoveredVisitor, 
                        exploredVisitor
                    );
                }

                exploredVisitor?.Invoke(current, cameFrom);
            }
        }
    }
}
