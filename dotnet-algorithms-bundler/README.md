# Algorithms and Data Structures: Bundler CLI

This repository contains a CLI for "minifying" and bundling functionality from [dotnet-algorithms](https://github.com/volpav/dotnet-algorithms/tree/master/dotnet-algorithms) repository.

# Building & Running

After cloning this repository, execute the following from the root folder to build the project:

    cd dotnet-algorithms-bundler/
    
    dotnet restore
    dotnet build
    
Now, go to the output directory:

    cd bin/Debug/netcoreapp1.0/

Run the CLI by issuing the following command: 
    
    dotnet run dotnet-algorithms-bundler.dll 
        --include=io,dfs,dijkstra 
        --output-to=./algo.cs

The above will create `algo.cs` file in the current folder with the following algorithms included:

- High-performance I/O facade;
- Depth-first search algorithm for exploring a graph;
- Dijkstra's algorithm for finding shortest path; 

To get a list of all possible modules/algorithms to export, run:

    dotnet run dotnet-algorithms-bundler.dll --help

**Important**: Make sure the folder containing main project sources (`dotnet-algorithms`) can be discovered by traversing up the file system tree (it is the case when you just clone the entire repository). Otherwise, the bundler won't know where to take sources from.

# License

All the code, just like with the main project, is available under [MIT license](https://opensource.org/licenses/MIT).  