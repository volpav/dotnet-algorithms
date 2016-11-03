using System.Linq;
using System.Collections.Generic;

using Algorithms.IO;

namespace Algorithms.Graphs
{
    public class Edge
    {
        public Vertex FromVertex { get; set; }
        public Vertex ToVertex { get; set; }
        public int? Weight { get; set; }

        public Edge() : this(null, null, -1) { }
        
        public Edge(Vertex fromVertex, Vertex toVertex) : this(fromVertex, toVertex, null) { }
        
        public Edge(Vertex fromVertex, Vertex toVertex, int? weight)
        {
            FromVertex = fromVertex;
            ToVertex = toVertex;
            Weight = weight;
        }
    }

    public class Vertex
    {
        public int Index { get; set; }
        public List<Edge> Edges { get; set; }

        public Vertex() : this(-1) { }

        public Vertex(int index)
        {
            Index = index;
            Edges = new List<Edge>();
        }

        public override string ToString()
        {
            return Index.ToString();
        }

        public void AddEdge(Vertex toVertex, int? weight = null)
        {
            Edges.Add(new Edge(this, toVertex, weight));
        }
    }

    public static class Graph
    {
        public static int[,] ConstantWeights(int n, int weight = 1, int[][] adjacencyList = null)
        {
            int[,] weights = new int[n, n];

            if (adjacencyList == null)
            {
                weights = GenerateFullWeights(n, weight);
            }
            else
            {
                for (int i = 0; i < adjacencyList.Length; i++)
                {
                    int[] edges = adjacencyList[i];

                    for (int j = 0; j < edges.Length; j++)
                    {
                        weights[i, edges[j]] = weight;
                    }
                }
            }

            return weights;
        }

        public static Vertex[] ConstantWeights(Vertex[] vertexList, int weight = 1)
        {
            foreach (Vertex vertex in vertexList)
            {
                foreach (Edge edge in vertex.Edges)
                {
                    edge.Weight = weight;
                }
            }

            return vertexList;
        }

        private static int[,] GenerateFullWeights(int n, int weight)
        {
            int[,] weights = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        weights[i, j] = weight;
                    }
                    else
                    {
                        weights[i, j] = 0;                        
                    }
                    
                }
            }

            return weights;
        }

        public static int[,] AsAdjacencyMatrix(Scanner scanner, bool directed = false, bool weighted = false)
        {
            int n = scanner.NextInt();
            int m = scanner.NextInt();

            int[,] vertices = new int[n, n];

            while (m > 0)
            {
                int a = scanner.NextInt() - 1;
                int b = scanner.NextInt() - 1;

                int w = weighted ? scanner.NextInt() : 1;

                vertices[a, b] = w;

                if (!directed)
                {
                    vertices[b, a] = w;
                }

                m--;
            }

            return vertices;
        }

        public static int[][] AsAdjacencyList(Scanner scanner, bool directed = false)
        {
            int[,] weights = null;

            return AsAdjacencyList(scanner, out weights, directed, weighted: false);
        }

        public static int[][] AsAdjacencyList(Scanner scanner, out int[,] weights, bool directed = false, bool weighted = false)
        {
            int n = scanner.NextInt();
            int m = scanner.NextInt();

            List<int>[] vertices = Enumerable.Range(0, n)
                .Select(i => new List<int>())
                .ToArray();

            weights = new int[n, n];

            while (m > 0)
            {
                int a = scanner.NextInt() - 1;
                int b = scanner.NextInt() - 1;

                if (weighted)
                {
                    int w = scanner.NextInt();

                    weights[a, b] = w;

                    if (!directed)
                    {
                        weights[b, a] = w;
                    }
                }

                vertices[a].Add(b);

                if (!directed)
                {
                    vertices[b].Add(a);
                }

                m--;
            }

            return vertices
                .Select(v => v.ToArray())
                .ToArray();
        }

        public static Vertex[] AsVertexList(Scanner scanner, bool directed = false, bool weighted = false)
        {
            int n = scanner.NextInt();
            int m = scanner.NextInt();

            Vertex[] vertices = Enumerable.Range(0, n)
                .Select(i => new Vertex(i))
                .ToArray();

            while (m > 0)
            {
                int a = scanner.NextInt() - 1;
                int b = scanner.NextInt() - 1;

                int? w = weighted ? new int?(scanner.NextInt()) : null;

                vertices[a].AddEdge(vertices[b], w);

                if (!directed)
                {
                    vertices[b].AddEdge(vertices[a], w);
                }

                m--;
            }

            return vertices;
        }
    }
}
