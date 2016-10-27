using System;
using System.Linq;
using System.Collections.Generic;

using Algorithms.DataStructures;

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
        /// <param name="adjacencyList">Adjacency list.</param>
        /// <param name="start">Starting vertex.</param>
        /// <param name="visitor">Vertex visitor.</param>
        public static void DFS(int[][] adjacencyList, int start, Action<int> visitor)
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

                    var edges = adjacencyList[current];
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
        /// Executes a breadth-first traversal of a given graph.
        /// </summary>
        /// <param name="adjacencyList">Adjacency list.</param>
        /// <param name="start">Starting vertex.</param>
        /// <param name="visitor">Vertex visitor.</param>
        public static void BFS(int[][] adjacencyList, int start, Action<int> visitor)
        {
            var s = new Queue<int>();
            var discoveredVertexIndicies = new HashSet<int>();

            s.Enqueue(start);

            while (s.Count > 0)
            {
                var current = s.Dequeue();
                
                if (!discoveredVertexIndicies.Contains(current))
                {
                    discoveredVertexIndicies.Add(current);

                    visitor(current);

                    var edges = adjacencyList[current];
                    var totalEdges = edges.Length;

                    for (var i = 0; i < totalEdges; i++)
                    {
                        s.Enqueue(edges[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Executes a breadth-first traversal of a given graph.
        /// </summary>
        /// <param name="vertices">Graph vertices.</param>
        /// <param name="start">Starting vertex.</param>
        /// <param name="visitor">Vertex visitor.</param>
        public static void BFS(Vertex[] vertices, Vertex start, Action<Vertex> visitor)
        {
            var s = new Queue<Vertex>();
            var discoveredVertexIndicies = new HashSet<int>();

            s.Enqueue(start);

            while (s.Count > 0)
            {
                var current = s.Dequeue();
                var index = current.Index;

                if (!discoveredVertexIndicies.Contains(index))
                {
                    discoveredVertexIndicies.Add(index);

                    visitor(current);

                    var edges = current.Edges;
                    var totalEdges = edges.Count;

                    for (var i = 0; i < totalEdges; i++)
                    {
                        s.Enqueue(edges[i].ToVertex);
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
        /// <param name="adjacencyList">Adjacency list.</param>
        /// <param name="start">Starting vertex.</param>
        /// <param name="discoveredVisitor">Vertex visitor, once discovered (arguments are current vertex as well as vertex of origin).</param>
        /// <param name="exploredVisitor">Vertex visitor, once fully explored (arguments are current vertex as well as vertex of origin).</param>
        public static void DFS(int[][] adjacencyList, int start, Action<int, int> discoveredVisitor, Action<int, int> exploredVisitor = null)
        {
            DFS(adjacencyList, start, start, new HashSet<int>(), discoveredVisitor, exploredVisitor);
        }

        /// <summary>
        /// Executes a recursive breadth-first traversal of a given graph.
        /// </summary>
        /// <param name="vertices">Vertices.</param>
        /// <param name="start">Starting vertex.</param>
        /// <param name="discoveredVisitor">Vertex visitor, once discovered (arguments are current vertex as well as vertex of origin).</param>
        /// <param name="exploredVisitor">Vertex visitor, once fully explored (arguments are current vertex as well as vertex of origin).</param>
        public static void BFS(Vertex[] vertices, Vertex start, Action<Vertex, Vertex> discoveredVisitor, Action<Vertex, Vertex> exploredVisitor = null)
        {
            var level = new Queue<int>();

            level.Enqueue(start.Index);

            BFS(vertices, level, new HashSet<int>(), discoveredVisitor, exploredVisitor);
        }

        /// <summary>
        /// Executes a recursive depth-first traversal of a given graph.
        /// </summary>
        /// <param name="adjacencyList">Adjacency list.</param>
        /// <param name="start">Starting vertex.</param>
        /// <param name="discoveredVisitor">Vertex visitor, once discovered (arguments are current vertex as well as vertex of origin).</param>
        /// <param name="exploredVisitor">Vertex visitor, once fully explored (arguments are current vertex as well as vertex of origin).</param>
        public static void BFS(int[][] adjacencyList, int start, Action<int, int> discoveredVisitor, Action<int, int> exploredVisitor = null)
        {
            var level = new Queue<int>();

            level.Enqueue(start);

            BFS(adjacencyList, level, new HashSet<int>(), discoveredVisitor, exploredVisitor);
        }

        /// <summary>
        /// Executes a recursive breadth-first traversal of a given graph.
        /// </summary>
        /// <param name="vertices">Vertices.</param>
        /// <param name="level">Level to explore.</param>
        /// <param name="discoveredVertexIndicies">A set of all the discovered vertices.</param>
        /// <param name="discoveredVisitor">Vertex visitor, once discovered (arguments are current vertex as well as vertex of origin).</param>
        /// <param name="exploredVisitor">Vertex visitor, once fully explored (arguments are current vertex as well as vertex of origin).</param>
        private static void BFS(
            Vertex[] vertices,
            Queue<int> level,
            HashSet<int> discoveredVertexIndicies,
            Action<Vertex, Vertex> discoveredVisitor,
            Action<Vertex, Vertex> exploredVisitor = null)
        {
            int cameFrom = -1, current = -1;
            Queue<int> nextLevel = new Queue<int>();
            Func<int> cf = () => cameFrom < 0 ? current : cameFrom;

            while (level.Count > 0)
            {
                current = level.Dequeue();

                if (!discoveredVertexIndicies.Contains(current))
                {
                    discoveredVertexIndicies.Add(current);
                    discoveredVisitor(vertices[current], vertices[cf()]);

                    var edges = vertices[current].Edges;
                    var totalEdges = edges.Count;

                    for (var i = 0; i < totalEdges; i++)
                    {
                        var v = edges[i].ToVertex;

                        if (!discoveredVertexIndicies.Contains(v.Index))
                        {
                            nextLevel.Enqueue(v.Index);
                        }
                    }
                }

                cameFrom = current;
            }

            if (current >= 0)
            {
                exploredVisitor?.Invoke(vertices[current], vertices[cf()]);

                BFS(
                    vertices, 
                    nextLevel, 
                    discoveredVertexIndicies, 
                    discoveredVisitor, 
                    exploredVisitor
                );
            }
        }

        /// <summary>
        /// Executes a recursive breadth-first traversal of a given graph.
        /// </summary>
        /// <param name="adjacencyList">Adjacency list.</param>
        /// <param name="level">Level to explore.</param>
        /// <param name="discoveredVertexIndicies">A set of all the discovered vertices.</param>
        /// <param name="discoveredVisitor">Vertex visitor, once discovered (arguments are current vertex as well as vertex of origin).</param>
        /// <param name="exploredVisitor">Vertex visitor, once fully explored (arguments are current vertex as well as vertex of origin).</param>
        private static void BFS(
            int[][] adjacencyList, 
            Queue<int> level,
            HashSet<int> discoveredVertexIndicies,
            Action<int, int> discoveredVisitor, 
            Action<int, int> exploredVisitor = null)
        {
            int cameFrom = -1, current = -1;
            Queue<int> nextLevel = new Queue<int>();
            Func<int> cf = () => cameFrom < 0 ? current : cameFrom;

            while (level.Count > 0)
            {
                current = level.Dequeue();

                if (!discoveredVertexIndicies.Contains(current))
                {
                    discoveredVertexIndicies.Add(current);
                    discoveredVisitor(current, cf());

                    var edges = adjacencyList[current];
                    var totalEdges = edges.Length;

                    for (var i = 0; i < totalEdges; i++)
                    {
                        var v = edges[i];

                        if (!discoveredVertexIndicies.Contains(v))
                        {
                            nextLevel.Enqueue(v);
                        }
                    }
                }

                cameFrom = current;
            }

            if (current >= 0)
            {
                exploredVisitor?.Invoke(current, cf());

                BFS(
                    adjacencyList, 
                    nextLevel, 
                    discoveredVertexIndicies, 
                    discoveredVisitor, 
                    exploredVisitor
                );
            }
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
        /// <param name="adjacencyList">Adjacency list.</param>
        /// <param name="current">Current vertex.</param>
        /// <param name="cameFrom">Vertex coming from.</param>
        /// <param name="discoveredVertexIndicies">A set of all the discovered vertices.</param>
        /// <param name="discoveredVisitor">Vertex visitor, once discovered (arguments are current vertex as well as vertex of origin).</param>
        /// <param name="exploredVisitor">Vertex visitor, once fully explored (arguments are current vertex as well as vertex of origin).</param>
        private static void DFS(
            int[][] adjacencyList, 
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

                var edges = adjacencyList[current];
                var totalEdges = edges.Length;

                for (var i = 0; i < totalEdges; i++)
                {
                    DFS(
                        adjacencyList, 
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

        /// <summary>
        /// Executes non-recursive Dijkstra for finding out shortest path to all the notes of a given graph from a given node.
        /// </summary>
        /// <param name="adjacencyList">Adjacency list.</param>
        /// <param name="weights">Edge weights.</param>
        /// <param name="start">Node to find shortest paths from.</param>
        /// <returns>A pair of arrays, first - containing shortest path costs to each of the nodes, second - parent nodes visited from a given node (for traceability of the path).</returns>
        public static Tuple<int[], int[]> Dijkstra(
            int[][] adjacencyList, 
            int[,] weights, 
            int start)
        {
            var n = adjacencyList.Length;
            var infinity = int.MaxValue - 1000;
    
            var distance = new int[n];
            var previous = new int[n];
            var queue = new MinHeap<int>((x, y) => distance[x] - distance[y]);
    
            for (var i = 0; i < n; i++)
            {
                distance[i] = infinity;
                previous[i] = -1;
            }
    
            distance[start] = 0;
    
            queue.AddRange(Enumerable.Range(0, n));
    
            while (queue.Count > 0)
            {
                var u = queue.PeekMin();
    
                for (var i = 0; i < adjacencyList[u].Length; i++)
                {
                    var v = adjacencyList[u][i];
                    var newDistance = distance[u] + weights[u, v];
    
                    if (newDistance < distance[v])
                    {
                        distance[v] = newDistance;
                        previous[v] = u;
                    }
                }
    
                queue.ExtractMin();
            }
    
            return new Tuple<int[], int[]>(distance, previous);
        }

        /// <summary>
        /// Executes non-recursive Dijkstra for finding out shortest path to all the notes of a given graph from a given node.
        /// </summary>
        /// <param name="vertexList">Vertex list.</param>
        /// <param name="start">Node to find shortest paths from.</param>
        /// <returns>A pair of arrays, first - containing shortest path costs to each of the nodes, second - parent nodes visited from a given node (for traceability of the path).</returns>
        public static Tuple<int[], int[]> Dijkstra(
            Vertex[] vertexList, 
            Vertex start)
        {
            var n = vertexList.Length;
            var infinity = int.MaxValue - 1000;
    
            var distance = new int[n];
            var previous = new int[n];
            var queue = new MinHeap<int>((x, y) => distance[x] - distance[y]);
    
            for (var i = 0; i < n; i++)
            {
                distance[i] = infinity;
                previous[i] = -1;
            }
    
            distance[start.Index] = 0;
    
            queue.AddRange(Enumerable.Range(0, n));
    
            while (queue.Count > 0)
            {
                var u = queue.PeekMin();
    
                foreach (var edge in vertexList[u].Edges)
                {
                    var v = edge.ToVertex.Index;

                    var newDistance = distance[u] + (edge.Weight != null ? edge.Weight.Value : 0);
    
                    if (newDistance < distance[v])
                    {
                        distance[v] = newDistance;
                        previous[v] = u;
                    }
                }
    
                queue.ExtractMin();
            }
    
            return new Tuple<int[], int[]>(distance, previous);
        }

        /// <summary>
        /// Computes minimum spanning tree of a given graph using Prim's algorithm.
        /// </summary>
        /// <param name="adjacencyList">Adjacency list.</param>
        /// <param name="weights">Edge weights.</param>
        /// <param name="start">Node to start from.</param>
        /// <returns>A pair. First item - array representing a tree, second - total minimum weight.</returns>
        public static Tuple<int[], int> MST(
            int[][] adjacencyList, 
            int[,] weights, 
            int start)
        {
            var n = adjacencyList.Length;
            var explored = new HashSet<Tuple<int, int>>();

            int weight = 0, k = 0;
            var tree = new int[n];

            var queue = new MinHeap<Tuple<int, int>>((x, y) =>
            {
                return weights[x.Item1, x.Item2] - weights[y.Item1, y.Item2];
            });

            Action<int> addNeighbors = (u) =>
            {
                explored.Add(new Tuple<int, int>(u, u));

                for (var i = 0; i < adjacencyList[u].Length; i++)
                {
                    var v = adjacencyList[u][i];

                    var smaller = u < v ? u : v;
                    var larger = u > v ? u : v;
                    var key = new Tuple<int, int>(smaller, larger);

                    if (!explored.Contains(key))
                    {
                        explored.Add(key);
                        
                        queue.Add(new Tuple<int, int>(u, v));
                    }
                }
            };

            addNeighbors(start);
            tree[k++] = start;

            while (k < n)
            {
                var u = queue.ExtractMin();

                weight += weights[u.Item1, u.Item2];
                tree[k++] = u.Item2;

                addNeighbors(u.Item2);
            }
    
            return new Tuple<int[], int>(tree, weight);
        }

        /// <summary>
        /// Computes minimum spanning tree of a given graph using Prim's algorithm.
        /// </summary>
        /// <param name="vertexList">Vertex list.</param>
        /// <param name="start">Node to start from.</param>
        /// <returns>A pair. First item - array representing a tree, second - total minimum weight.</returns>
        public static Tuple<int[], int> MST(
            Vertex[] vertexList, 
            Vertex start)
        {
            var n = vertexList.Length;
            var explored = new HashSet<Tuple<int, int>>();

            int weight = 0, k = 0;
            var tree = new int[n];

            var queue = new MinHeap<Edge>((x, y) =>
            {
                return (x.Weight ?? 0) - (y.Weight ?? 0);
            });

            Action<Vertex> addNeighbors = (node) =>
            {
                var u = node.Index;

                explored.Add(new Tuple<int, int>(u, u));

                foreach (var edge in node.Edges)
                {
                    var v = edge.ToVertex.Index;

                    var smaller = u < v ? u : v;
                    var larger = u > v ? u : v;
                    var key = new Tuple<int, int>(smaller, larger);

                    if (!explored.Contains(key))
                    {
                        explored.Add(key);
                        
                        queue.Add(edge);
                    }
                }
            };

            addNeighbors(start);
            tree[k++] = start.Index;

            while (k < n)
            {
                var u = queue.ExtractMin();

                weight += (u.Weight ?? 0);
                tree[k++] = u.ToVertex.Index;

                addNeighbors(u.ToVertex);
            }
    
            return new Tuple<int[], int>(tree, weight);
        }
    }
}
