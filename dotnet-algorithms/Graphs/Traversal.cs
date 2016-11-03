using System;
using System.Linq;
using System.Collections.Generic;

using Algorithms.DataStructures;

namespace Algorithms.Graphs
{
    public static class GraphTraversal
    {
        public static void DFS(int[][] adjacencyList, int start, Action<int> visitor)
        {
            Stack<int> s = new Stack<int>();
            HashSet<int> discoveredVertexIndicies = new HashSet<int>();

            s.Push(start);

            while (s.Count > 0)
            {
                int current = s.Pop();
                
                if (!discoveredVertexIndicies.Contains(current))
                {
                    discoveredVertexIndicies.Add(current);

                    visitor(current);

                    int[] edges = adjacencyList[current];
                    int totalEdges = edges.Length;

                    for (int i = 0; i < totalEdges; i++)
                    {
                        s.Push(edges[i]);
                    }
                }
            }
        }

        public static void DFS(Vertex[] vertices, Vertex start, Action<Vertex> visitor)
        {
            Stack<Vertex> s = new Stack<Vertex>();
            HashSet<int> discoveredVertexIndicies = new HashSet<int>();

            s.Push(start);

            while (s.Count > 0)
            {
                Vertex current = s.Pop();
                int index = current.Index;

                if (!discoveredVertexIndicies.Contains(index))
                {
                    discoveredVertexIndicies.Add(index);

                    visitor(current);

                    IList<Edge> edges = current.Edges;
                    int totalEdges = edges.Count;

                    for (int i = 0; i < totalEdges; i++)
                    {
                        s.Push(edges[i].ToVertex);
                    }
                }
            }
        }

        public static void BFS(int[][] adjacencyList, int start, Action<int> visitor)
        {
            Queue<int> s = new Queue<int>();
            HashSet<int> discoveredVertexIndicies = new HashSet<int>();

            s.Enqueue(start);

            while (s.Count > 0)
            {
                int current = s.Dequeue();
                
                if (!discoveredVertexIndicies.Contains(current))
                {
                    discoveredVertexIndicies.Add(current);

                    visitor(current);

                    int[] edges = adjacencyList[current];
                    int totalEdges = edges.Length;

                    for (int i = 0; i < totalEdges; i++)
                    {
                        s.Enqueue(edges[i]);
                    }
                }
            }
        }

        public static void BFS(Vertex[] vertices, Vertex start, Action<Vertex> visitor)
        {
            Queue<Vertex> s = new Queue<Vertex>();
            HashSet<int> discoveredVertexIndicies = new HashSet<int>();

            s.Enqueue(start);

            while (s.Count > 0)
            {
                Vertex current = s.Dequeue();
                int index = current.Index;

                if (!discoveredVertexIndicies.Contains(index))
                {
                    discoveredVertexIndicies.Add(index);

                    visitor(current);

                    IList<Edge> edges = current.Edges;
                    int totalEdges = edges.Count;

                    for (int i = 0; i < totalEdges; i++)
                    {
                        s.Enqueue(edges[i].ToVertex);
                    }
                }
            }
        }

        public static void DFS(Vertex[] vertices, Vertex start, Action<Vertex, Vertex> discoveredVisitor, Action<Vertex, Vertex> exploredVisitor = null)
        {
            DFS(vertices, start.Index, start.Index, new HashSet<int>(), discoveredVisitor, exploredVisitor);
        }

        public static void DFS(int[][] adjacencyList, int start, Action<int, int> discoveredVisitor, Action<int, int> exploredVisitor = null)
        {
            DFS(adjacencyList, start, start, new HashSet<int>(), discoveredVisitor, exploredVisitor);
        }

        public static void BFS(Vertex[] vertices, Vertex start, Action<Vertex, Vertex> discoveredVisitor, Action<Vertex, Vertex> exploredVisitor = null)
        {
            Queue<int> level = new Queue<int>();

            level.Enqueue(start.Index);

            BFS(vertices, level, new HashSet<int>(), discoveredVisitor, exploredVisitor);
        }

        public static void BFS(int[][] adjacencyList, int start, Action<int, int> discoveredVisitor, Action<int, int> exploredVisitor = null)
        {
            Queue<int> level = new Queue<int>();

            level.Enqueue(start);

            BFS(adjacencyList, level, new HashSet<int>(), discoveredVisitor, exploredVisitor);
        }

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

                    IList<Edge> edges = vertices[current].Edges;
                    int totalEdges = edges.Count;

                    for (int i = 0; i < totalEdges; i++)
                    {
                        Vertex v = edges[i].ToVertex;

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

                    int[] edges = adjacencyList[current];
                    int totalEdges = edges.Length;

                    for (int i = 0; i < totalEdges; i++)
                    {
                        int v = edges[i];

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

                IList<Edge> edges = vertices[current].Edges;
                int totalEdges = edges.Count;

                for (int i = 0; i < totalEdges; i++)
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

                int[] edges = adjacencyList[current];
                int totalEdges = edges.Length;

                for (int i = 0; i < totalEdges; i++)
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

        public static Tuple<int[], int[]> Dijkstra(
            int[][] adjacencyList, 
            int[,] weights, 
            int start)
        {
            int n = adjacencyList.Length;
            int infinity = int.MaxValue - 1000;
    
            int[] distance = new int[n];
            int[] previous = new int[n];
            MinHeap<int> queue = new MinHeap<int>((x, y) => distance[x] - distance[y]);
    
            for (int i = 0; i < n; i++)
            {
                distance[i] = infinity;
                previous[i] = -1;
            }
    
            distance[start] = 0;
    
            queue.AddRange(Enumerable.Range(0, n));
    
            while (queue.Count > 0)
            {
                int u = queue.PeekMin();
    
                for (int i = 0; i < adjacencyList[u].Length; i++)
                {
                    int v = adjacencyList[u][i];
                    int newDistance = distance[u] + weights[u, v];
    
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

        public static Tuple<int[], int[]> Dijkstra(
            Vertex[] vertexList, 
            Vertex start)
        {
            int n = vertexList.Length;
            int infinity = int.MaxValue - 1000;
    
            int[] distance = new int[n];
            int[] previous = new int[n];
            MinHeap<int> queue = new MinHeap<int>((x, y) => distance[x] - distance[y]);
    
            for (int i = 0; i < n; i++)
            {
                distance[i] = infinity;
                previous[i] = -1;
            }
    
            distance[start.Index] = 0;
    
            queue.AddRange(Enumerable.Range(0, n));
    
            while (queue.Count > 0)
            {
                int u = queue.PeekMin();
    
                foreach (Edge edge in vertexList[u].Edges)
                {
                    int v = edge.ToVertex.Index;

                    int newDistance = distance[u] + (edge.Weight != null ? edge.Weight.Value : 0);
    
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

        public static Tuple<int[], int> MST(
            int[][] adjacencyList, 
            int[,] weights, 
            int start)
        {
            int n = adjacencyList.Length;
            HashSet<Tuple<int, int>> explored = new HashSet<Tuple<int, int>>();

            int weight = 0, k = 0;
            int[] tree = new int[n];

            MinHeap<Tuple<int, int>> queue = new MinHeap<Tuple<int, int>>((x, y) =>
            {
                return weights[x.Item1, x.Item2] - weights[y.Item1, y.Item2];
            });

            Action<int> addNeighbors = (u) =>
            {
                explored.Add(new Tuple<int, int>(u, u));

                for (int i = 0; i < adjacencyList[u].Length; i++)
                {
                    int v = adjacencyList[u][i];

                    int smaller = u < v ? u : v;
                    int larger = u > v ? u : v;
                    Tuple<int, int> key = new Tuple<int, int>(smaller, larger);

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
                Tuple<int, int> u = queue.ExtractMin();

                weight += weights[u.Item1, u.Item2];
                tree[k++] = u.Item2;

                addNeighbors(u.Item2);
            }
    
            return new Tuple<int[], int>(tree, weight);
        }

        public static Tuple<int[], int> MST(
            Vertex[] vertexList, 
            Vertex start)
        {
            int n = vertexList.Length;
            HashSet<Tuple<int, int>> explored = new HashSet<Tuple<int, int>>();

            int weight = 0, k = 0;
            int[] tree = new int[n];

            MinHeap<Edge> queue = new MinHeap<Edge>((x, y) =>
            {
                return (x.Weight ?? 0) - (y.Weight ?? 0);
            });

            Action<Vertex> addNeighbors = (node) =>
            {
                int u = node.Index;

                explored.Add(new Tuple<int, int>(u, u));

                foreach (Edge edge in node.Edges)
                {
                    int v = edge.ToVertex.Index;

                    int smaller = u < v ? u : v;
                    int larger = u > v ? u : v;
                    Tuple<int, int> key = new Tuple<int, int>(smaller, larger);

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
                Edge u = queue.ExtractMin();

                weight += (u.Weight ?? 0);
                tree[k++] = u.ToVertex.Index;

                addNeighbors(u.ToVertex);
            }
    
            return new Tuple<int[], int>(tree, weight);
        }
    }
}
