using System.Linq;
using System.Collections.Generic;

using Algorithms.IO;

namespace Algorithms.Graphs
{
    /// <summary>
    /// Represents an edge.
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Represents a start vertex.
        /// </summary>
        public Vertex FromVertex { get; set; }

        /// <summary>
        /// Represents an end vertex.
        /// </summary>
        public Vertex ToVertex { get; set; }

        /// <summary>
        /// Represents an edge weight.
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        public Edge() : this(null, null, -1) { }

        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        /// <param name="fromVertex">Start vertex.</param>
        /// <param name="toVertex">End vertex.</param>
        public Edge(Vertex fromVertex, Vertex toVertex) : this(fromVertex, toVertex, null) { }

        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        /// <param name="fromVertex">Start vertex.</param>
        /// <param name="toVertex">End vertex.</param>
        /// <param name="weight">Weight.</param>
        public Edge(Vertex fromVertex, Vertex toVertex, int? weight)
        {
            FromVertex = fromVertex;
            ToVertex = toVertex;
            Weight = weight;
        }
    }

    /// <summary>
    /// Represents a graph vertex.
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// Gets or sets zero-based index of a vertex.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the list of edges going out of this vertex.
        /// </summary>
        public List<Edge> Edges { get; set; }

        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        public Vertex() : this(-1) { }

        /// <summary>
        /// Represents a new instance of an object.
        /// </summary>
        /// <param name="index">Zero-based vertex index within the graph.</param>
        public Vertex(int index)
        {
            Index = index;
            Edges = new List<Edge>();
        }

        /// <summary>
        /// Returns a string representation of the given object.
        /// </summary>
        /// <returns>A string representation of the given object.</returns>
        public override string ToString()
        {
            return Index.ToString();
        }

        /// <summary>
        /// Connects this vertex to a given one uni-directionally (no back-link).
        /// </summary>
        /// <param name="toVertex">Vertex to connect to.</param>
        /// <param name="weight">Optional weight to apply to an edge.</param>
        public void AddEdge(Vertex toVertex, int? weight = null)
        {
            Edges.Add(new Edge(this, toVertex, weight));
        }
    }

    /// <summary>
    /// Provides methods for instantiating graphs.
    /// </summary>
    public static class Graph
    {
        /// <summary>
        /// Returns an adjacency matrix using the given scanner as a data source.
        /// </summary>
        /// <param name="scanner">Scanner.</param>
        /// <param name="directed">Value indicating whether the graph is directed.</param>
        /// <param name="weighted">Value indicating whether the graph is weighted.</param>
        /// <returns>Adjacency matrix.</returns>
        public static int[,] AsAdjacencyMatrix(Scanner scanner, bool directed = false, bool weighted = false)
        {
            // Reading out the number of nodes.
            var n = scanner.NextInt();

            // Reading out the number of edges.
            var m = scanner.NextInt();

            var vertices = new int[n, n];

            while (m > 0)
            {
                // Vertex number is *usually* 1-based.
                var a = scanner.NextInt() - 1;
                var b = scanner.NextInt() - 1;

                // Reading out weight if we need to.
                int w = weighted ? scanner.NextInt() : 1;

                vertices[a, b] = w;

                // For undirected graphs, adding a back edge.
                if (!directed)
                {
                    vertices[b, a] = w;
                }

                m--;
            }

            return vertices;
        }

        /// <summary>
        /// Returns an adjacency list using the given scanner as a data source.
        /// </summary>
        /// <param name="scanner">Scanner.</param>
        /// <param name="directed">Value indicating whether the graph is directed.</param>
        /// <returns>Adjacency list.</returns>
        public static int[][] AsAdjacencyList(Scanner scanner, bool directed = false)
        {
            int[,] weights = null;

            return AsAdjacencyList(scanner, out weights, directed, weighted: false);
        }

        /// <summary>
        /// Returns an adjacency list (plus, fills out the weights, if needed) using the given scanner as a data source.
        /// </summary>
        /// <param name="scanner">Scanner.</param>
        /// <param name="weights">Weights to be filled in (in case of weighted graphs).</param>
        /// <param name="directed">Value indicating whether the graph is directed.</param>
        /// <param name="weighted">Value indicating whether the graph is weighted.</param>
        /// <returns>Adjacency list.</returns>
        public static int[][] AsAdjacencyList(Scanner scanner, out int[,] weights, bool directed = false, bool weighted = false)
        {
            // Reading out the number of nodes.
            var n = scanner.NextInt();

            // Reading out the number of edges.
            var m = scanner.NextInt();

            var vertices = Enumerable.Range(0, n).Select(i => new List<int>()).ToArray();

            weights = new int[n, n];

            while (m > 0)
            {
                // Vertex number is *usually* 1-based.
                var a = scanner.NextInt() - 1;
                var b = scanner.NextInt() - 1;

                if (weighted)
                {
                    // Reading out weight if we need to.
                    int w = scanner.NextInt();

                    weights[a, b] = w;

                    // For undirected graphs, 
                    if (!directed)
                    {
                        weights[b, a] = w;
                    }
                }

                vertices[a].Add(b);

                // For undirected graphs, adding a back edge.
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

        /// <summary>
        /// Returns a set of vertices using the given scanner as a data source.
        /// </summary>
        /// <param name="scanner">Scanner.</param>
        /// <param name="directed">Value indicating whether the graph is directed.</param>
        /// <param name="weighted">Value indicating whether the graph is weighted.</param>
        /// <returns>A set of vertices.</returns>
        public static Vertex[] AsVertexList(Scanner scanner, bool directed = false, bool weighted = false)
        {
            // Reading out the number of nodes.
            var n = scanner.NextInt();

            // Reading out the number of edges.
            var m = scanner.NextInt();

            // Defining vertices.
            var vertices = Enumerable.Range(0, n)
                .Select(i => new Vertex(i))
                .ToArray();

            while (m > 0)
            {
                // Vertex number is *usually* 1-based.
                var a = scanner.NextInt() - 1;
                var b = scanner.NextInt() - 1;

                // Reading out weight if we need to.
                int? w = weighted ? new int?(scanner.NextInt()) : null;

                vertices[a].AddEdge(vertices[b], w);

                // For undirected graphs, adding a back edge.
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
