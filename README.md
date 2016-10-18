# Algorithms and Data Structures (written in C#)

This repository contains a collection of algorithms and data structures written in C# and primarily aimed for use in competitive programming.

[![Build Status](https://travis-ci.org/volpav/dotnet-algorithms.svg?branch=master)](https://travis-ci.org/volpav/dotnet-algorithms)

# Contents

This repository contains (I'm updating this list as I go):

- **I/O**: 
  - High-performance input/output facade (taken from [Kattis website](https://open.kattis.com/help/csharp));
- **Data structures**:
  - Min-heap (priority queue);  
- **Graphs**:
  - Convenient way of initializing (directed/undirected, weighted/unweighted) graph as:
    - Vertex set;
    - Adjacency matrix;
    - Adjacency list;
  - Graph traversal algorithms:
    - Depth-first-search (DFS):
      - Using vertex set (iterative + recursive with backtracking);
      - Using adjacency matrix (iterative + recursive with backtracking);
    - Breadth-first-search (BFS):
      - Using vertex set (iterative + recursive with backtracking);
      - Using adjacency matrix (iterative + recursive with backtracking);
  - Working with vertex subsets:    
    - Dijkstra's algorithm for finding minimum path from a given node;       
- **Geometry**:
  - Primitives (points, line segments);
  - Find intersection between two line segments;  

# Contributing

It's as easy as "1-2-3":

1. Clone `master` branch;
2. Make the changes you want;
3. Create a [Pull Request](https://github.com/volpav/dotnet-algorithms/pulls);

I appreciate every effort, whether that is fixing bugs, improving existing algorithms' performance, adding more convenient interfaces, contributing new algorithms or just improving documentation. 

# Feedback

If you have any questions or comments, don't hesitate to shoot me an email at [volpav@gmail.com](mailto:volpav@gmail.com).

# License

All the code is available under [MIT license](https://opensource.org/licenses/MIT).
