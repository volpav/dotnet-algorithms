using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;

using Algorithms.Bundler.SourceCode;

namespace Algorithms.Bundler
{
    /// <summary>
    /// Represents a bundler.
    /// </summary>
    public class Bundler
    {
        private readonly Action<string, bool> _logger;

        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        /// <param name="logger">Logger action.</param>
        public Bundler(Action<string, bool> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Processes and bundles the given files into a single output stream.
        /// </summary>
        /// <param name="files">Files to process and bundle.</param>
        /// <param name="writeTo">Output stream to write to.</param>
        public void Bundle(string[] files, System.IO.Stream writeTo)
        {
            var list = new string[files.Length];

            // Creating a copy of the file list in order not to mutate the input.
            files.CopyTo(list, 0);

            Reoder(list);

            // Parsing each input file into a syntax tree.
            var trees = files.Select(file => CSharpSyntaxTree.ParseText(File.ReadAllText(file)));

            // Processing each tree.
            var processedTrees = trees.Select(tree =>
            {
                return SourceCodeRewriteTask.RewriteWithAll(tree, new SourceCodeRewriteTask[] {
                    new RemoveCommentsTask(),
                    new RemoveNamespacesTask()
                });
            });
        }

        /// <summary>
        /// Reorders files so that the concatenated output has better logical structure.
        /// </summary>
        /// <param name="files">Files to order.</param>
        private void Reoder(string[] files)
        {
            for (var i = 1; i < files.Length; i++)
            {
                // Moving I/O helper to the top. We don't care about the rest.
                if (files[i].EndsWith("Scanner.cs", StringComparison.OrdinalIgnoreCase))
                {
                    var temp = files[0];
                    files[0] = files[i];
                    files[i] = temp;

                    break;
                }
            }
        }
    }
}
